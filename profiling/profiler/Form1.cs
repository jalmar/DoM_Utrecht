using System;
using System.Collections.ObjectModel;
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

            comboBoxTransform.DataSource = Enum.GetValues(typeof(Transformation));
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
//            bool writeToDisk = TiffData.WriteToDisk(new MemoryStream(), "c:\\Users\\Jens\\Documents\\test.tif", 128, 128, 0, 0);

            _imageDimensionX = Convert.ToInt32(TextBoxImageDimensionX.Text);
            _imageDimensionY = Convert.ToInt32(TextBoxImageDimensionY.Text);
            _imageDimensionZ = Convert.ToInt32(TextBoxImageDimensionZ.Text);

            // construct context
            var context = new ComputeContext(_selectedComputeDevice.Type, new ComputeContextPropertyList(_selectedComputePlatform), null, IntPtr.Zero);
            CalculateConvolution(context);
        }

        private void CalculateConvolution(ComputeContext computeContext)
        {           
            Console.WriteLine("Computing...");
            Console.WriteLine("Reading kernel...");
            
            String kernelString;
            using (var sr = new StreamReader("..\\..\\..\\convolution.cl"))
                kernelString = sr.ReadToEnd();

            Console.WriteLine("Reading kernel... done");

            float[] selectedTransformation = Transformations.GetTransformation((Transformation)comboBoxTransform.SelectedItem, _imageDimensionX, _imageDimensionY, _imageDimensionZ);

            //create openCL program
            ComputeProgram computeProgram = new ComputeProgram(computeContext, kernelString);

            computeProgram.Build(computeContext.Devices, null, null, IntPtr.Zero);

            ComputeProgramBuildStatus computeProgramBuildStatus = computeProgram.GetBuildStatus(computeContext.Devices[0]);
            Console.WriteLine(computeProgramBuildStatus);

            String buildLog = computeProgram.GetBuildLog(computeContext.Devices[0]);
            Console.WriteLine(buildLog);

            // TODO remove this line, is added nog testing
            _sourceFilename = "..\\..\\..\\data\\fluorophores_radial_45_label_500_persistence_length_2000.csv";

            float[] readFluorophores = CsvData.ReadFluorophores(_sourceFilename);

//create buffers
    //csv
            ComputeBuffer<float> mt_fluorophores_coordsXYZw = new ComputeBuffer<float>(computeContext, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, readFluorophores);

    //transformation matrix
//            ComputeImageFormat transformationMatrixFormat = new ComputeImageFormat(ComputeImageChannelOrder.Intensity, ComputeImageChannelType.SignedInt16);
//            ComputeImage2D transformationMatrix = new ComputeImage2D(computeContext, ComputeMemoryFlags.ReadWrite, transformationMatrixFormat, 128, 128, 0, IntPtr.Zero);

            ComputeBuffer<float> transformationMatrix = new ComputeBuffer<float>(computeContext, ComputeMemoryFlags.ReadOnly, selectedTransformation);

    //resulting image
            ushort[] resultImageDimension = new ushort[_imageDimensionX * _imageDimensionY * _imageDimensionZ];
            ComputeBuffer<ushort> resultImage = new ComputeBuffer<ushort>(computeContext, ComputeMemoryFlags.WriteOnly, resultImageDimension);
            
//Create the kernel & set memory
            ComputeKernel convolutionKernel = computeProgram.CreateKernel("convolve_fluophors");
            
            //Kernel arguments
            convolutionKernel.SetMemoryArgument(0, mt_fluorophores_coordsXYZw);
            convolutionKernel.SetMemoryArgument(1, transformationMatrix);

            //Create the command queue
            ComputeCommandQueue computeCommandQueue = new ComputeCommandQueue(computeContext, computeContext.Devices[0], ComputeCommandQueueFlags.None);
            
            //Call transform fluo

            ComputeEventList events = new ComputeEventList();

            computeCommandQueue.Write(resultImage, false, 0, 0, IntPtr.Zero, events);
            computeCommandQueue.Execute(convolutionKernel, null, new long[1024], null, events);

            
            convolutionKernel.SetValueArgument(2, _imageDimensionX);
            convolutionKernel.SetValueArgument(3, _imageDimensionY);
            convolutionKernel.SetMemoryArgument(4, resultImage);


            MemoryStream data = new MemoryStream();

//            GCHandle arrCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
//            computeCommandQueue.ReadFromImage(resultImage, IntPtr.Zero, true, events);
//            computeCommandQueue.Finish();

//            arrCHandle.Free();

//Save to disk
            
//            Console.WriteLine("Writing microtubule fluorophores to file");
//            CsvData.WriteToDisk("mt_fluorophores.csv", null);
            
//            Console.WriteLine("Writing microtubule segements to file");
//            CsvData.WriteToDisk("mt_segments.csv", null);

//            Console.WriteLine("Writing microtubule tubulins to file");
//            CsvData.WriteToDisk("mt_tubulins.csv", null);

            _saveFilename = "wf_radial_45_label_500_persistence_length.tif";

            TiffData.WriteToDisk(data, _sourceFilename, 128, 128);
            
//            computeCommandQueue.Write(CLnumAtom, false, 0, 0, IntPtr.Zero, null);
//            computeCommandQueue.Execute(kernelAtomInc, new long[] { }, new long[1] { 1 }, new long[1] { 1 }, null);
            
//            computeCommandQueue.Write(CLnumAtom, false, 0, 0,IntPtr.Zero, null);
//            computeCommandQueue.Write<int>(CLnumNoAtom, new int[1], null);

//            computeCommandQueue.Execute(kernelAtomInc, null, new long[1] { N }, new long[1] { 1 }, null);
//            computeCommandQueue.Execute(kernelNoAtomInc, null, new long[1] { N }, new long[1] { 1 }, null);

//            computeCommandQueue.Read(CLnumAtom, false, 0, 0, IntPtr.Zero, null);
//            int[] numNoAtom = computeCommandQueue.Read<int>(CLnumNoAtom, null);
            
//            arrC = new float[count];
//            GCHandle arrCHandle = GCHandle.Alloc(arrC, GCHandleType.Pinned);
//            computeCommandQueue.Read(coordsResult, false, 0, count, arrCHandle.AddrOfPinnedObject(), events);
//            computeCommandQueue.Finish();

//            arrCHandle.Free();


//            for (int i = 0; i < count; i++)
//                richTextBox1.Text += "{" + arrA[i] + "} + {" + arrB[i] + "} = {" + arrC[i] + "} \n";
            
//            Console.WriteLine("Number of items is " + N);
            Console.WriteLine("****************************************");
//            Console.WriteLine("Increment test - Expected result is " + N);
//            Console.WriteLine("Atomics: " + CLnumAtom);
//            Console.WriteLine("Atomics: " + CLnumAtom.ToString()[0]);
            Console.WriteLine("****************************************");

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
    }
}