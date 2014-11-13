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

            ICollection<ComputeKernel> computeKernels = kernels.CreateAllKernels();

            KernelComboBox.DataSource = computeKernels;
            KernelComboBox.DisplayMember = "FunctionName";

            //Call convolve_image_2d kernel
//            var kernel = (ComputeKernel)computeKernels.Select(c => c.FunctionName == "convolve_image_2d");
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

//create buffers
    //csv
            ComputeBuffer<short> mt_fluorophores_coordsX = new ComputeBuffer<short>(computeContext, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, new short[1]);
            ComputeBuffer<short> mt_fluorophores_coordsY = new ComputeBuffer<short>(computeContext, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, new short[1]);
            ComputeBuffer<short> mt_fluorophores_coordsZ = new ComputeBuffer<short>(computeContext, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, new short[1]);

            ComputeBuffer<short> mt_segments_coordsX = new ComputeBuffer<short>(computeContext, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, new short[1]);
            ComputeBuffer<short> mt_segments_coordsY = new ComputeBuffer<short>(computeContext, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, new short[1]);
            ComputeBuffer<short> mt_segments_coordsZ = new ComputeBuffer<short>(computeContext, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, new short[1]);

            ComputeBuffer<short> mt_tubulins_coordsX = new ComputeBuffer<short>(computeContext, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, new short[1]);
            ComputeBuffer<short> mt_tubulins_coordsY = new ComputeBuffer<short>(computeContext, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, new short[1]);
            ComputeBuffer<short> mt_tubulins_coordsZ = new ComputeBuffer<short>(computeContext, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, new short[1]);


    //transformation matrix
            ComputeImageFormat transformationMatrixFormat = new ComputeImageFormat(ComputeImageChannelOrder.Intensity, ComputeImageChannelType.SignedInt16);
            ComputeImage2D transformationMatrix = new ComputeImage2D(computeContext, ComputeMemoryFlags.ReadWrite, transformationMatrixFormat, 128, 128, 0, IntPtr.Zero);

    //resulting image
            ComputeImageFormat resultImageFormat = new ComputeImageFormat(ComputeImageChannelOrder.Intensity, ComputeImageChannelType.SignedInt16);
            ComputeImage2D resultImage = new ComputeImage2D(computeContext, ComputeMemoryFlags.ReadWrite, resultImageFormat, 128, 128, 0, IntPtr.Zero);
            
//Create the kernel & set memory
            ComputeKernel convolutionKernel = computeProgram.CreateKernel("convolve_image_2d");
            
            //Kernel arguments
            convolutionKernel.SetMemoryArgument(0, mt_fluorophores_coordsX);
            convolutionKernel.SetMemoryArgument(1, mt_fluorophores_coordsY);
            convolutionKernel.SetMemoryArgument(2, mt_fluorophores_coordsZ);

            convolutionKernel.SetMemoryArgument(3, mt_segments_coordsX);
            convolutionKernel.SetMemoryArgument(4, mt_segments_coordsY);
            convolutionKernel.SetMemoryArgument(5, mt_segments_coordsZ);

            convolutionKernel.SetMemoryArgument(6, mt_tubulins_coordsX);
            convolutionKernel.SetMemoryArgument(7, mt_tubulins_coordsY);
            convolutionKernel.SetMemoryArgument(8, mt_tubulins_coordsZ);

            convolutionKernel.SetMemoryArgument(9, transformationMatrix);
            convolutionKernel.SetMemoryArgument(10, resultImage);
            
            

//Create the command queue
            ComputeCommandQueue computeCommandQueue = new ComputeCommandQueue(computeContext, computeContext.Devices[0], ComputeCommandQueueFlags.None);

//Catch events
            ComputeEventList events = new ComputeEventList();

            computeCommandQueue.WriteToImage(IntPtr.Zero,resultImage,false, events);
            computeCommandQueue.Execute(convolutionKernel, null, new long[1024], null, events);

            
            MemoryStream data = new MemoryStream();

            GCHandle arrCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            computeCommandQueue.ReadFromImage(resultImage, IntPtr.Zero, true, events);
            computeCommandQueue.Finish();

            arrCHandle.Free();

//Save to disk
            
            Console.WriteLine("Writing microtubule fluorophores to file");
            CsvData.WriteToDisk("mt_fluorophores.csv", null, null);
            
            Console.WriteLine("Writing microtubule segements to file");
            CsvData.WriteToDisk("mt_segments.csv", null, null);

            Console.WriteLine("Writing microtubule tubulins to file");
            CsvData.WriteToDisk("mt_tubulins.csv", null, null);

            TiffData.WriteToDisk(data, "wf_radial_45_label_500_persistence_length.tif", 128, 128);
            
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
                Filter = "Image files (*.tif, *.tiff) | *.tif; *.tiff; *.TIF; *.TIFF;",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                labelImage.Text = fdlg.FileName;
            }
        }

        private void ReadTiff(String filename = @"D:\spots_snr_3_SD_2.2_coords _test.csv")
        {
            var reader = new CsvData();
            List<DataRecord> readCsvList = reader.ReadCsvList(filename);

            foreach (var dataRecord in readCsvList)
            {
                Console.WriteLine(
                    String.Format(
                        "dataRecord.id = {0}   dataRecord.X = {1}   dataRecord.Y = {2}   dataRecord.Intensity = {3} \n",
                        dataRecord.Id, dataRecord.X, dataRecord.Y, dataRecord.Intensity));
            }
        }

        private void buttonSelectDir_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.ShowDialog();

            if (fbd.SelectedPath == "")
                return;

            Console.WriteLine("Looking for file *.tif, *.tiff");
            
            List<string> files = Directory
                .GetFiles(fbd.SelectedPath, "*.*")
                .Where(file => file.ToLower().EndsWith("tif") || file.ToLower().EndsWith("tiff"))
                .ToList();

            Console.WriteLine("Files found: " + files.Count, "Message");

            labelDirSelected.Text = fbd.SelectedPath;
        }
    }
}