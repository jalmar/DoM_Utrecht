using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using BitMiracle.LibTiff.Classic;
using Orientation = BitMiracle.LibTiff.Classic.Orientation;

namespace profiler.io
{
    class TiffData
    {
//        public static bool WriteToDisk(Tiff data, String fileName)
//        {
//            return false;
//        }
        public static bool WriteToDisk(ushort[][] data, String fileName, int imageWidth, int imageHeight, int samplesPerPixel = 1, Compression compression = Compression.NONE, int bitsPerSample = 16)
        {
            if (data == null)
                throw new Exception("no data provided");

            using (Tiff imageData = Tiff.Open(fileName, "w"))
            {
            }
            foreach (ushort[] imageData in data)
            {
                
            }
            return false;
        }
        public static bool WriteToDisk(ushort[] data, String fileName, int imageWidth, int imageHeight, int samplesPerPixel = 1, Compression compression = Compression.NONE, int bitsPerSample = 16)
        {//call this function after kernel convolution
            if (data == null)
                throw new Exception("no data provided");
            
            using (Tiff imageData = Tiff.Open(fileName, "w"))
            {
                imageData.SetField(TiffTag.IMAGEWIDTH, imageWidth.ToString(CultureInfo.InvariantCulture));
                imageData.SetField(TiffTag.IMAGELENGTH, imageHeight.ToString(CultureInfo.InvariantCulture));
                imageData.SetField(TiffTag.COMPRESSION, compression);
                imageData.SetField(TiffTag.BITSPERSAMPLE, bitsPerSample.ToString(CultureInfo.InvariantCulture));
//                imageData.SetField(TiffTag.SAMPLESPERPIXEL, samplesPerPixel);
                imageData.SetField(TiffTag.XRESOLUTION, 1);
                imageData.SetField(TiffTag.YRESOLUTION, 1);
                imageData.SetField(TiffTag.DATETIME, DateTime.Now);
//                imageData.SetField(TiffTag.ROWSPERSTRIP, imageHeight.ToString(CultureInfo.InvariantCulture));
                imageData.SetField(TiffTag.PLANARCONFIG, PlanarConfig.CONTIG);
                imageData.SetField(TiffTag.PHOTOMETRIC, Photometric.MINISBLACK);
                imageData.SetField(TiffTag.FILLORDER, FillOrder.MSB2LSB);
                imageData.SetField(TiffTag.ORIENTATION, Orientation.TOPLEFT);
                imageData.SetField(TiffTag.RESOLUTIONUNIT, ResUnit.CENTIMETER);

                imageData.SetField(TiffTag.ARTIST, "ProjectStorm");
                imageData.SetField(TiffTag.IMAGEDESCRIPTION, "Test data constructed by openCL kernel of project storm");

                for (int i = 0; i < imageHeight; i++)
                {
                    Byte[] buffer = new byte[data.Length * sizeof(ushort)];

                    Buffer.BlockCopy(data, i*imageWidth, buffer, 0, buffer.Length);
                    imageData.WriteScanline(buffer, i);
                }
                
//                imageData.WriteDirectory();
                imageData.FlushData();
                imageData.Close();
            }
            
            return true;
        }

        public void TestTiffWrite()
        {
            int width1 = 800;
            int height1 = 800;
            string fileName1 = "../../random.tif";
            using (Tiff output = Tiff.Open(fileName1, "w"))
            {
                output.SetField(TiffTag.IMAGEWIDTH, width1);
                output.SetField(TiffTag.IMAGELENGTH, height1);
                output.SetField(TiffTag.SAMPLESPERPIXEL, 1);
                output.SetField(TiffTag.BITSPERSAMPLE, 16);
                output.SetField(TiffTag.ORIENTATION, Orientation.TOPLEFT);
                output.SetField(TiffTag.ROWSPERSTRIP, height1);
                output.SetField(TiffTag.XRESOLUTION, 88.0);
                output.SetField(TiffTag.YRESOLUTION, 88.0);
                output.SetField(TiffTag.RESOLUTIONUNIT, ResUnit.CENTIMETER);
                output.SetField(TiffTag.PLANARCONFIG, PlanarConfig.CONTIG);
                output.SetField(TiffTag.PHOTOMETRIC, Photometric.MINISBLACK);
                output.SetField(TiffTag.COMPRESSION, Compression.NONE);
                output.SetField(TiffTag.FILLORDER, FillOrder.MSB2LSB);
                output.SetField(TiffTag.DATETIME, DateTime.Now);
                output.SetField(TiffTag.ARTIST, "ProjectStorm");

                var random = new Random();
                for (int i = 0; i < height1; i++)
                {
                    var samples = new short[width1];
                    for (int j = 0; j < width1; j++)
                        samples[j] = (short)random.Next(0, short.MaxValue);

                    var buffer = new byte[samples.Length * sizeof(short)];
                    Buffer.BlockCopy(samples, 0, buffer, 0, buffer.Length);
                    output.WriteScanline(buffer, i);
                }
            }
        }

        public static Tiff ReadFromDisk(String fileName = @"D:\myMultipageFile.tif")
        {
            using (Tiff image = Tiff.Open(fileName, "r"))
            {
                if (image == null)
                    return null;

                bool subDirectory = image.SetSubDirectory(0);
                bool directory = image.SetDirectory(0);
                bool isTiled = image.IsTiled();
                string dataFileName = image.FileName();
                bool lastDirectory = image.LastDirectory();

                short numberOfDirectories = image.NumberOfDirectories();
                int numberOfStrips = image.NumberOfStrips();
                int numberOfTiles = image.NumberOfTiles();

                Console.WriteLine("{0} directories in {1} using the NumberOfDirectories() method", numberOfDirectories, image.FileName());

                int dircount = 0;
                do
                {
                    dircount++;
                } while (image.ReadDirectory());

                Console.WriteLine("{0} directories in {1} using iterator", dircount, image.FileName());

                return image;
            }
        }
    }
}
