using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Cloo;
using profiler.io;

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
        }

        private void PlatformCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null)
                return;

            var selectedPlatform = (ComputePlatform) comboBox.SelectedItem;

            DeviceCombox.DataSource = selectedPlatform.Devices.ToList();
            DeviceCombox.DisplayMember = "Name";

            Console.WriteLine("Selected platform : " + selectedPlatform.Name);
        }

        private void DeviceCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox == null)
                return;

            var selectedDevice = (ComputeDevice) comboBox.SelectedItem;

            Console.WriteLine("Selected device : " + selectedDevice.Name);
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            var selectedComputePlatform = (ComputePlatform) PlatformCombox.SelectedItem;
            var selectedComputeDevice = (ComputeDevice) DeviceCombox.SelectedItem;

            var context = new ComputeContext(selectedComputeDevice.Type,
                new ComputeContextPropertyList(selectedComputePlatform), null, IntPtr.Zero);
            CalculateConvolution(context);
        }

        private void CalculateConvolution(ComputeContext computeContext)
        {           
            Console.WriteLine("Computing...");
            Console.WriteLine("Reading data file...");

            TiffReader.Read();

            Console.WriteLine("Reading data file... done");

            throw new NotImplementedException("Call openCL kernel");

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
            var reader = new CsvReader();
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

            //            var fdlg = new Open
            //            {
            //                Title = "C# Corner Open File Dialog",
            //                InitialDirectory = @"c:\",
            //                Filter = "Image files (*.tif, *.tiff, *.png) | *.tif; *.tiff; *.png",
            //                FilterIndex = 2,
            //                RestoreDirectory = true
            //            };
            //            if (fdlg.ShowDialog() == DialogResult.OK)
            //            {
            //                labelImage.Text = fdlg.FileName;
            //            }
        }
    }
}