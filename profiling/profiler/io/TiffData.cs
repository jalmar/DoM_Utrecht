using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using BitMiracle.LibTiff.Classic;
using Orientation = BitMiracle.LibTiff.Classic.Orientation;

namespace profiler.io
{
    class TiffData
    {
        public static void WriteToDisk(ushort[][] data, String fileName, int imageWidth, int imageHeight, int samplesPerPixel = 1, Compression compression = Compression.NONE, int bitsPerSample = 16)
        {
            if (data == null)
                throw new Exception("no data provided");

            using (Tiff imagesData = Tiff.Open(fileName, "w"))
            {
                for (uint page = 0; page < data.Length; page++)
                {
                    imagesData.SetField(TiffTag.IMAGEWIDTH, imageWidth.ToString(CultureInfo.InvariantCulture));
                    imagesData.SetField(TiffTag.IMAGELENGTH, imageHeight.ToString(CultureInfo.InvariantCulture));
                    imagesData.SetField(TiffTag.COMPRESSION, compression);
                    imagesData.SetField(TiffTag.BITSPERSAMPLE, bitsPerSample.ToString(CultureInfo.InvariantCulture));
//                imageData.SetField(TiffTag.SAMPLESPERPIXEL, samplesPerPixel);
                    imagesData.SetField(TiffTag.XRESOLUTION, 1);
                    imagesData.SetField(TiffTag.YRESOLUTION, 1);
                    imagesData.SetField(TiffTag.DATETIME, DateTime.Now);
//                imageData.SetField(TiffTag.ROWSPERSTRIP, imageHeight.ToString(CultureInfo.InvariantCulture));
                    imagesData.SetField(TiffTag.PLANARCONFIG, PlanarConfig.CONTIG);
                    imagesData.SetField(TiffTag.PHOTOMETRIC, Photometric.MINISBLACK);
                    imagesData.SetField(TiffTag.FILLORDER, FillOrder.MSB2LSB);
                    imagesData.SetField(TiffTag.ORIENTATION, Orientation.TOPLEFT);
                    imagesData.SetField(TiffTag.RESOLUTIONUNIT, ResUnit.CENTIMETER);

                    imagesData.SetField(TiffTag.ARTIST, "ProjectStorm");
                    imagesData.SetField(TiffTag.IMAGEDESCRIPTION, "Test data constructed by openCL kernel of project storm");

                    // specify that it's a page within the multipage file
                    imagesData.SetField(TiffTag.SUBFILETYPE, FileType.PAGE);
                    // specify the page number
                    imagesData.SetField(TiffTag.PAGENUMBER, page, data.Length);

                    for (int i = 0; i < imageHeight; i++)
                    {
                        Byte[] buffer = new byte[data[page].Length * sizeof(ushort)];

                        Buffer.BlockCopy(data, i * imageWidth, buffer, 0, buffer.Length);
                        imagesData.WriteScanline(buffer, i);
                    }

                    imagesData.WriteDirectory();
                }

                imagesData.FlushData();
            }
        }
        public static void WriteToDisk(float[] data, String fileName, int imageWidth, int imageHeight, int samplesPerPixel = 1, Compression compression = Compression.NONE, int bitsPerSample = 16)
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
                imageData.SetField(TiffTag.COPYRIGHT,
                    "ProjectStorm profiler \u00A9" + DateTime.Now.Year.ToString(CultureInfo.InvariantCulture));

                imageData.SetField(TiffTag.DOCUMENTNAME, "ProjectStorm");
                imageData.SetField(TiffTag.ARTIST, "ProjectStorm");
                imageData.SetField(TiffTag.IMAGEDESCRIPTION, "Test data constructed by openCL kernel of project storm");
                imageData.SetField(TiffTag.SOFTWARE, "ProjectStorm profiler " + Assembly.GetExecutingAssembly().GetName().Version);

//                Byte[] buffer = new byte[data.Length * sizeof(ushort)];

//                for (int i = 0; i < data.Length; i++)
//                {
//                    byte[] bytes = BitConverter.GetBytes(data[i]);
//                    buffer[2*i] = bytes[0];
//                    buffer[2*i+1] = bytes[1];
//                }
                Console.WriteLine("ScanlineSize :" + imageData.ScanlineSize());
//                Console.WriteLine(imageData.st.StripSize());
//                Tiff.ShortsToByteArray(data, 0, data.Length,buffer,0);


                int rasterScanlineSize = imageData.RasterScanlineSize();
                int scanlineSize = imageData.ScanlineSize();
                
                for (int i = 0; i < imageHeight; i++)
                {

                    float[] rowData = new float[imageWidth];
                    for (int j = 0; j < imageWidth; j++)
                    {
                        rowData[j] = data[i*imageWidth + j];
                    }

                    Byte[] buffer = new byte[rowData.Length * sizeof(float)];
   
                    Buffer.BlockCopy(rowData, 0, buffer, 0, buffer.Length);
                    TiffCodec[] configuredCodecs = imageData.GetConfiguredCodecs();
//                    TiffType.FLOAT
//                imageData.WriteTile(buffer,0, 0, i, 0, 0);
//                    imageData.WriteEncodedStrip(i, buffer, imageWidth * sizeof(float));
                    imageData.WriteRawStrip(i, buffer, imageWidth);
//                    imageData.WriteScanline(buffer, i);
                }
                Console.WriteLine(imageData.ScanlineSize());
                imageData.FlushData();
            }
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
