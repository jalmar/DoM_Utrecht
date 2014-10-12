using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BitMiracle.LibTiff.Classic;
using Cloo;

namespace profiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            TopMost = true;

            // pick first platform
            ReadOnlyCollection<ComputePlatform> platforms = ComputePlatform.Platforms;

            PlatformCombox.DataSource = platforms.ToList();
            PlatformCombox.DisplayMember = "Name";


            // create context with all gpu devices
//            ComputeContext context = new ComputeContext(ComputeDeviceTypes.Gpu, new ComputeContextPropertyList(platform), null, IntPtr.Zero);

            // create a command queue with first gpu found
//            ComputeCommandQueue queue = new ComputeCommandQueue(context, context.Devices[0], ComputeCommandQueueFlags.None);

//           var reader = new CsvReader();
//           List<DataRecord> readCsvList = reader.ReadCsvList(@"E:\spots_snr_3_SD_2.2_coords _test.csv");

//            foreach (var dataRecord in readCsvList)
//            {
//                Console.WriteLine(String.Format("dataRecord.id = {0}   dataRecord.X = {1}   dataRecord.Y = {2}   dataRecord.Intensity = {3} \n", dataRecord.Id, dataRecord.X, dataRecord.Y, dataRecord.Intensity));
//            }
        }

        private void PlatformCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null) 
                return;
            
            var selectedPlatform = (ComputePlatform)comboBox.SelectedItem;

            DeviceCombox.DataSource = selectedPlatform.Devices.ToList();
            DeviceCombox.DisplayMember = "Name";

            Console.WriteLine("Selected platform : " + selectedPlatform.Name);
        }

        private void DeviceCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null)
                return;

            var selectedDevice = (ComputeDevice)comboBox.SelectedItem;

            Console.WriteLine("Selected device : " + selectedDevice.Name);
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            var selectedComputePlatform = (ComputePlatform)PlatformCombox.SelectedItem;
            var selectedComputeDevice = (ComputeDevice)DeviceCombox.SelectedItem;

            var context = new ComputeContext(selectedComputeDevice.Type, new ComputeContextPropertyList(selectedComputePlatform), null, IntPtr.Zero);
            CalculateConvolution(context);
        }

        private void CalculateConvolution(ComputeContext context)
        {
            throw new NotImplementedException();
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            var fdlg = new OpenFileDialog
            {
                Title = "C# Corner Open File Dialog",
                InitialDirectory = @"c:\",
                Filter = "Image files (*.tif, *.tiff, *.png) | *.tif; *.tiff; *.png",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if(fdlg.ShowDialog() == DialogResult.OK)
            {
                labelImage.Text = fdlg.FileName;
            }
        }
    }
}