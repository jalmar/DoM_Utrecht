using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Cloo;
using profiler.io;

namespace profiler
{
    public partial class Form1 : Form
    {
        private ComputePlatform selectedComputePlatform = null;
        private ComputeDevice selectedComputeDevice = null;

        private int ImageDimensionX = 0;
        private int ImageDimensionY = 0;
        private int ImageDimensionZ = 0;

        private String sourceFilename = String.Empty;
        private String saveFilename = String.Empty;

        private String sourceDir = String.Empty;
        private String saveDir = String.Empty;

        public Form1()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            TopMost = true;

            // pick first platform
            ReadOnlyCollection<ComputePlatform> platforms = ComputePlatform.Platforms;

            PlatformCombox.DataSource = platforms.ToList();
            PlatformCombox.DisplayMember = "Name";
        }

        private void LoadKernels(ComputeContext computeContext)
        {
            String kernelString;
            using (var sr = new StreamReader("../FittingKernelLMA.cl"))
                kernelString = sr.ReadToEnd();

            var kernels = new ComputeProgram(computeContext, kernelString);

            kernels.Build(computeContext.Devices, null, null, IntPtr.Zero);

            ComputeProgramBuildStatus computeProgramBuildStatus = kernels.GetBuildStatus(computeContext.Devices[0]);
            Console.WriteLine(computeProgramBuildStatus);

            String buildLog = kernels.GetBuildLog(computeContext.Devices[0]);
            Console.WriteLine(buildLog);
        }

        private void PlatformCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null)
                return;

            selectedComputePlatform = (ComputePlatform) comboBox.SelectedItem;

            DeviceCombox.DataSource = selectedComputePlatform.Devices.ToList();
            DeviceCombox.DisplayMember = "Name";

            Console.WriteLine("Selected platform : " + selectedComputePlatform.Name);
        }

        private void DeviceCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null)
                return;

            var selectedDevice = (ComputeDevice) comboBox.SelectedItem;

            Console.WriteLine("Selected device : " + selectedDevice.Name);

            selectedComputePlatform = (ComputePlatform)PlatformCombox.SelectedItem;
            selectedComputeDevice = (ComputeDevice)DeviceCombox.SelectedItem;

            var context = new ComputeContext(selectedComputeDevice.Type,
                new ComputeContextPropertyList(selectedComputePlatform), null, IntPtr.Zero);

            LoadKernels(context);
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
//            bool writeToDisk = TiffData.WriteToDisk(new MemoryStream(), "c:\\Users\\Jens\\Documents\\test.tif", 128, 128, 0, 0);

//            Tiff dataImage = TiffData.Read();

            ImageDimensionX = Convert.ToInt32(TextBoxImageDimensionX.Text);
            ImageDimensionY = Convert.ToInt32(TextBoxImageDimensionY.Text);
            ImageDimensionZ = Convert.ToInt32(TextBoxImageDimensionZ.Text);

            var context = new ComputeContext(selectedComputeDevice.Type, new ComputeContextPropertyList(selectedComputePlatform), null, IntPtr.Zero);
            CalculateConvolution(context);
        }

        private void CalculateConvolution(ComputeContext computeContext)
        {           
            Console.WriteLine("Computing...");
            Console.WriteLine("Reading data file...");

            Console.WriteLine("Reading data file... done");


            String kernelString = null;
//            using (var sr = new StreamReader("../FittingKernelLMA.cl"))
//                kernelString = sr.ReadToEnd();

            kernelString = @"
 __kernel void convolve_image_2d(
  __read_only float* a,
  __read_only float* b,
  __read_only float* c, 
  __read_only image2d_t d, 
  __write_only image2d_t e )
 {
    int2 coord = (int2)(get_global_id(0), get_global_id(1)); 
 }
 ";

            //d[index] = a[index] * b[index] * c[index];

            //create openCL program
            ComputeProgram computeProgram = new ComputeProgram(computeContext, kernelString);

            computeProgram.Build(computeContext.Devices, null, null, IntPtr.Zero);

            ComputeProgramBuildStatus computeProgramBuildStatus = computeProgram.GetBuildStatus(computeContext.Devices[0]);
            Console.WriteLine(computeProgramBuildStatus);

            String buildLog = computeProgram.GetBuildLog(computeContext.Devices[0]);
            Console.WriteLine(buildLog);

            float[] readFluorphors = CsvData.ReadFluorophores("../../../data/fluorophores_radial_45_label_500_persistence_length_2000.csv").ToArray();

//create buffers
    //csv
            ComputeBuffer<float> mt_fluorophores_coordsXYZw = new ComputeBuffer<float>(computeContext, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, readFluorphors);

    //transformation matrix
//            ComputeImageFormat transformationMatrixFormat = new ComputeImageFormat(ComputeImageChannelOrder.Intensity, ComputeImageChannelType.SignedInt16);
//            ComputeImage2D transformationMatrix = new ComputeImage2D(computeContext, ComputeMemoryFlags.ReadWrite, transformationMatrixFormat, 128, 128, 0, IntPtr.Zero);

            float dx = 0;
            float dy = 0;
            float dz = 0;

            float[] transformationMatrixArray = new float[]
            {
                ImageDimensionX, 0,0,dx,
                0,ImageDimensionY,0,dy,
                0,0,ImageDimensionZ, dz,
                0,0,0,1
            };



            ComputeBuffer<float> transformationMatrix = new ComputeBuffer<float>(computeContext, ComputeMemoryFlags.ReadOnly, transformationMatrixArray);

    //resulting image
            ushort[] resultImageDimension = new ushort[ImageDimensionX * ImageDimensionY * ImageDimensionZ];
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

            
            convolutionKernel.SetValueArgument(2, ImageDimensionX);
            convolutionKernel.SetValueArgument(3, ImageDimensionY);
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

            sourceFilename = "wf_radial_45_label_500_persistence_length.tif";
            saveFilename = "wf_radial_45_label_500_persistence_length.tif";

            TiffData.WriteToDisk(data, sourceFilename, 128, 128);
            
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
                labelSelectSourceFile.Text = fdlg.FileName;
            }
        }
        
        private void radioButtonSingleFile_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSingleFile.Enabled = true;
            groupBoxMultipleFiles.Enabled = false;
        }

        private void radioButtonMultipleFiles_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSingleFile.Enabled = false;
            groupBoxMultipleFiles.Enabled = true;
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
            }
        }

        private void buttonSelectDir_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.ShowDialog();

            if (fbd.SelectedPath == "")
                return;

            Console.WriteLine("Looking for file *.csv");

            labelSelectSourceDir.Text = fbd.SelectedPath;
        }

        private void buttonSaveOutputDir_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.ShowDialog();

            if (fbd.SelectedPath == "")
                return;

            labelSaveOutputDir.Text = fbd.SelectedPath;
        }
    }
}