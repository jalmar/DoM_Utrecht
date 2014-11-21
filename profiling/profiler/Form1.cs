using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Cloo;
using profiler.io;
using profiler.utils;

namespace profiler
{
    public partial class Form1 : Form
    {
        private ComputePlatform _selectedComputePlatform;
        private ComputeDevice _selectedComputeDevice;

        private int _imageDimensionX;
        private int _imageDimensionY;
        private int _imageDimensionZ;

        private String _sourceFilename = String.Empty;
        private String _saveFilename = String.Empty;

        private String _sourceDir = String.Empty;
        private String _saveDir = String.Empty;

        private const uint FluorophoreParameterCount = 4;
        
        public Form1()
        {
            _imageDimensionZ = 0;
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            TopMost = true;

            // Load platforms
            ReadOnlyCollection<ComputePlatform> platforms = ComputePlatform.Platforms;

            PlatformCombox.DataSource = platforms.ToList();
            PlatformCombox.DisplayMember = "Name";

            comboBoxTransform.DataSource = Enum.GetValues(typeof(TransformationType));

            //TODO need to be removed, nor for testing {
            _sourceFilename = "..\\..\\..\\data\\fluorophores_test.csv";
            textBoxSelectSourceFile.Text = _sourceFilename;
            _saveFilename = "..\\..\\..\\data\\fluorophores_test.tif";
            labelSaveOutputFile.Text = _saveFilename;
            comboBoxTransform.SelectedItem = TransformationType.Affine;
            //TODO }
        }

        private void PlatformCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null)
                return;

            _selectedComputePlatform = (ComputePlatform) comboBox.SelectedItem;

            DeviceCombox.DataSource = _selectedComputePlatform.Devices.ToList();
            DeviceCombox.DisplayMember = "Name";

            Console.WriteLine("Selected platform : " + _selectedComputePlatform.Name);
        }

        private void DeviceCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null)
                return;

            var selectedDevice = (ComputeDevice) comboBox.SelectedItem;

            Console.WriteLine("Selected device : " + selectedDevice.Name);

            _selectedComputePlatform = (ComputePlatform)PlatformCombox.SelectedItem;
            _selectedComputeDevice = (ComputeDevice)DeviceCombox.SelectedItem;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            SetOutputDimensions();

            // construct context
            var context = new ComputeContext(_selectedComputeDevice.Type, new ComputeContextPropertyList(_selectedComputePlatform), null, IntPtr.Zero);

            CalculateConvolution(context);
        }

        private void SetOutputDimensions()
        {
            if (TextBoxImageDimensionX.Text == String.Empty || TextBoxImageDimensionY.Text == String.Empty ||
                TextBoxImageDimensionZ.Text == String.Empty) throw new ArgumentOutOfRangeException(String.Format("Dimensions need to be set"));

            _imageDimensionX = Convert.ToInt32(TextBoxImageDimensionX.Text);
            _imageDimensionY = Convert.ToInt32(TextBoxImageDimensionY.Text);
            _imageDimensionZ = Convert.ToInt32(TextBoxImageDimensionZ.Text);
        }

        private void CalculateConvolution(ComputeContext computeContext)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            float dx;
            bool shiftXParse = float.TryParse(textBoxShiftX.Text, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out dx);
            if (!shiftXParse)
                throw new SyntaxErrorException(", needs to be .");

            float dy;
            bool shiftYParse = float.TryParse(textBoxShiftX.Text, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out dy);
            if (!shiftYParse)
                throw new SyntaxErrorException(", needs to be  .");

            float dz;
            bool shiftZParse = float.TryParse(textBoxShiftX.Text, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out dz);
            if (!shiftZParse)
                throw new SyntaxErrorException(", needs to be  .");

            int pixelCount = _imageDimensionX*_imageDimensionY*_imageDimensionZ;

            Console.WriteLine("Computing...");
            Console.WriteLine("Reading kernel...");

            String kernelPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            String kernelString;
            using (var sr = new StreamReader(kernelPath + "\\convolution.cl"))
                kernelString = sr.ReadToEnd();
            
            Console.WriteLine("Reading kernel... done");

            float[] selectedTransformation = Transformations.GetTransformation((TransformationType)comboBoxTransform.SelectedItem, 1.0f / float.Parse(textBoxPixelSize.Text), 1.0f / float.Parse(textBoxPixelSize.Text), 1.0f / float.Parse(textBoxPixelSize.Text), dx, dy, dz);

            //create openCL program
            ComputeProgram computeProgram = new ComputeProgram(computeContext, kernelString);
            
            computeProgram.Build(computeContext.Devices, null, null, IntPtr.Zero);

            ComputeProgramBuildStatus computeProgramBuildStatus = computeProgram.GetBuildStatus(_selectedComputeDevice);
            Console.WriteLine("computeProgramBuildStatus\n\t"+computeProgramBuildStatus);

            String buildLog = computeProgram.GetBuildLog(_selectedComputeDevice);
            Console.WriteLine("buildLog");
            if (buildLog.Equals("\n"))
                Console.WriteLine("\tbuildLog is empty...");
            else
                Console.WriteLine("\t" + buildLog);
            

            float[] fluorophores = CsvData.ReadFluorophores(_sourceFilename);

/////////////////////////////////////////////
// Create a Command Queue & Event List
/////////////////////////////////////////////
            ComputeCommandQueue computeCommandQueue = new ComputeCommandQueue(computeContext, _selectedComputeDevice, ComputeCommandQueueFlags.None);

            ComputeEventList transformFluorophoresEvents = new ComputeEventList(); 
            ComputeEventList convolveFluorophoresEvents = new ComputeEventList(); 
            

////////////////////////////////////////////////////////////////
// Create Buffers Transform
////////////////////////////////////////////////////////////////
            ComputeBuffer<float> fluorophoresCoords = new ComputeBuffer<float>(computeContext, ComputeMemoryFlags.ReadWrite, sizeof(float) * fluorophores.LongLength);

            ComputeBuffer<float> transformationMatrix = new ComputeBuffer<float>(computeContext, ComputeMemoryFlags.ReadOnly, sizeof(float) * selectedTransformation.LongLength);

/////////////////////////////////////////////
// Create the transformFluorophoresKernel
///////////////////////////////////////////////////////////
            ComputeKernel transformFluorophoresKernel = computeProgram.CreateKernel("transform_fluorophores");
            
/////////////////////////////////////////////
// Set the transformFluorophoresKernel arguments
/////////////////////////////////////////////
            transformFluorophoresKernel.SetMemoryArgument(0, fluorophoresCoords);
            transformFluorophoresKernel.SetMemoryArgument(1, transformationMatrix);

/////////////////////////////////////////////
// Configure the work-item structure
/////////////////////////////////////////////
            long[] globalWorkOffsetTransformFluorophoresKernel = null;
            long[] globalWorkSizeTransformFluorophoresKernel = new long[]   { fluorophores.Length };
            long[] localWorkSizeTransformFluorophoresKernel = null;

////////////////////////////////////////////////////////
// Enqueue the transformFluorophoresKernel for execution
////////////////////////////////////////////////////////

            transformFluorophoresEvents.Clear();

            computeCommandQueue.WriteToBuffer(fluorophores, fluorophoresCoords, true, null);
            computeCommandQueue.WriteToBuffer(selectedTransformation, transformationMatrix, true, null);
            
            computeCommandQueue.Execute(transformFluorophoresKernel, globalWorkOffsetTransformFluorophoresKernel, globalWorkSizeTransformFluorophoresKernel, localWorkSizeTransformFluorophoresKernel, null);
//            computeCommandQueue.ExecuteTask(transformFluorophoresKernel, transformFluorophoresEvents);

            float[] transformedFluorophores = new float[fluorophores.Length];

            computeCommandQueue.ReadFromBuffer(fluorophoresCoords, ref transformedFluorophores, true, null);
            
            computeCommandQueue.Finish();

            transformFluorophoresEvents.Clear();
            
            //TODO remove, only for testing
            for (int i = 0; i < transformedFluorophores.Length; i++)
            {
                Console.WriteLine(transformedFluorophores[i]);
            }
            // /TODO remove, only for testing

            stopwatch.Stop();
            Console.WriteLine("Transform fluophores duration:\n\t" + stopwatch.Elapsed);
            stopwatch.Reset();
            stopwatch.Start();
            // fluorophoresCoords are now transformed (done in place)
            
////////////////////////////////////////////////////////////////
// Create Buffers Convolve Fluorophores
////////////////////////////////////////////////////////////////
            ushort[] resultImageDimension = new ushort[pixelCount];
            ComputeBuffer<ushort> resultImage = new ComputeBuffer<ushort>(computeContext, ComputeMemoryFlags.WriteOnly, resultImageDimension);


/////////////////////////////////////////////
// Create the transformFluorophoresKernel
/////////////////////////////////////////////
            ComputeKernel convolveFluorophoresKernel = computeProgram.CreateKernel("convolve_fluorophores");


/////////////////////////////////////////////
// Set the convolveFluorophoresKernel arguments
/////////////////////////////////////////////
            convolveFluorophoresKernel.SetMemoryArgument(0, resultImage);
            convolveFluorophoresKernel.SetValueArgument(1, _imageDimensionX);
            convolveFluorophoresKernel.SetValueArgument(2, _imageDimensionY);
            convolveFluorophoresKernel.SetMemoryArgument(3, fluorophoresCoords);
            convolveFluorophoresKernel.SetLocalArgument(4, fluorophoresCoords.Count);
            convolveFluorophoresKernel.SetValueArgument(5, fluorophores.Length);

/////////////////////////////////////////////
// Configure the work-item structure
/////////////////////////////////////////////
            long[] globalWorkOffsetTransformConvolveFluorophoresKernel = null;
            long[] globalWorkSizeTransformConvolveFluorophoresKernel = new long[] { pixelCount };
            long[] localWorkSizeTransformConvolveFluorophoresKernel = null;
            
////////////////////////////////////////////////////////
// Enqueue the convolveFluorophoresKernel for execution
////////////////////////////////////////////////////////

            ushort[] resultImageData = new ushort[pixelCount];

            computeCommandQueue.WriteToBuffer(resultImageData, resultImage, false, convolveFluorophoresEvents);

            computeCommandQueue.Execute(convolveFluorophoresKernel, globalWorkOffsetTransformConvolveFluorophoresKernel, globalWorkSizeTransformConvolveFluorophoresKernel, localWorkSizeTransformConvolveFluorophoresKernel, convolveFluorophoresEvents);
           
            computeCommandQueue.ReadFromBuffer(resultImage, ref resultImageData, false, convolveFluorophoresEvents);

            computeCommandQueue.Finish();



            Console.WriteLine("Writing data to file...");
            TiffData.WriteToDisk(resultImageData, _saveFilename, _imageDimensionX, _imageDimensionY);
            Console.WriteLine("Writing data to file... done");

            stopwatch.Stop();
            Console.WriteLine("Convolve fluophores duration:\n\t" + stopwatch.Elapsed);
            Console.WriteLine("Computing... done");
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            var fdlg = new OpenFileDialog
            {
                Title = "C# Corner Open File Dialog",
                InitialDirectory = @"c:\",
                Filter = "Image files (*.csv) | *.csv; *.tiff; *.TIF; *.TIFF;",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBoxSelectSourceFile.Text = fdlg.FileName;
                _sourceFilename = fdlg.FileName;

                Console.WriteLine("Source file set to: \n\t" + _sourceFilename);
            }
        }
        
        private void radioButtonSingleFile_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSingleFile.Enabled = true;
            groupBoxMultipleFiles.Enabled = false;

            RadioButton radioButton = (RadioButton) sender;
            if (radioButton.Checked)
            {
                Console.WriteLine("Single file mode selected");
            }
        }

        private void radioButtonMultipleFiles_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSingleFile.Enabled = false;
            groupBoxMultipleFiles.Enabled = true;
            
            RadioButton radioButton = (RadioButton) sender;
            if (radioButton.Checked)
            {
                Console.WriteLine("Multiple files mode selected");
            }
        }

        private void buttonSaveOutputFile_Click(object sender, EventArgs e)
        {
            var fdlg = new SaveFileDialog
            {
                Title = "Save TIFF Data File",
                InitialDirectory = @"c:\",
                Filter = "Image files (*.tif, *.tiff) | *.tiff; *.tiff; *.TIF; *.TIFF;",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                labelSaveOutputFile.Text = fdlg.FileName;
                _saveFilename = fdlg.FileName;

                Console.WriteLine("Save file set to: \n\t" + _saveFilename);
            }
        }

        private void buttonSelectDir_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                labelSelectSourceDir.Text = fbd.SelectedPath;
                _sourceDir = fbd.SelectedPath;

                Console.WriteLine("Source dir set to: \n\t" + _sourceDir);
            }
        }

        private void buttonSaveOutputDir_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                labelSaveOutputDir.Text = fbd.SelectedPath;
                _saveDir = fbd.SelectedPath;

                Console.WriteLine("Save dir set to: \n\t" + _saveDir);
            }
        }

        private void comboBoxTransform_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("TransformationType type set to: \n\t" + ((ComboBox)sender).SelectedItem);
        }

        private void buttonListDeviceInfo_Click(object sender, EventArgs e)
        {
            foreach (var prop in _selectedComputeDevice.GetType().GetProperties())
            {
                Console.WriteLine(prop.Name + " = " + prop.GetValue(_selectedComputeDevice, null));
            }
        }
    }
}