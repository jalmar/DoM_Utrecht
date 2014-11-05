using System;
using System.Globalization;
using System.IO;
using BitMiracle.LibTiff.Classic;

namespace profiler.io
{
    class TiffData
    {
        public static bool WriteToDisk(MemoryStream data, string fileName, int width, int height, int bitsPerSample, int samplesPerPixel, Compression compression = Compression.NONE)
        {
            if (data == null)
                throw new Exception("no data provided");
            var ts = new TiffStream();
//            ts.Read(null, data.ToArray(), 0, (int)data.Length);

//            using (Tiff imageData = Tiff.Open(fileName, "w"))
//            {
//                imageData.SetField(TiffTag.IMAGEWIDTH, width.ToString(CultureInfo.InvariantCulture));
//                imageData.SetField(TiffTag.IMAGELENGTH, height.ToString(CultureInfo.InvariantCulture));
//                imageData.SetField(TiffTag.COMPRESSION, compression);
//                imageData.SetField(TiffTag.BITSPERSAMPLE, bitsPerSample.ToString(CultureInfo.InvariantCulture));
//                imageData.SetField(TiffTag.SAMPLESPERPIXEL, samplesPerPixel);
//                imageData.SetField(TiffTag.XRESOLUTION, 1);
//                imageData.SetField(TiffTag.YRESOLUTION, 1);
//                imageData.SetField(TiffTag.DATETIME, DateTime.Now);
//                imageData.SetField(TiffTag.ARTIST, "ProjectStorm");
//                imageData.SetField(TiffTag.RESOLUTIONUNIT, ResUnit.CENTIMETER);
//                imageData.SetField(TiffTag.IMAGEDESCRIPTION, "Data constructed by openCL kernel of project storm");

//                imageData.WriteRawStrip(0, data.ToArray(), (int) data.Length);
//                imageData.WriteDirectory();
//            }



            int width1 = 800;
            int height1 = 800;
            string fileName1 = "c:\\Users\\Jens\\Documents\\random.tif";
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

                Random random = new Random();
                for (int i = 0; i < height1; i++)
                {
                    short[] samples = new short[width1];
                    for (int j = 0; j < width1; j++)
                        samples[j] = (short)random.Next(0, short.MaxValue);

                    byte[] buffer = new byte[samples.Length * sizeof(short)];
                    Buffer.BlockCopy(samples, 0, buffer, 0, buffer.Length);
                    output.WriteScanline(buffer, i);
                }
            }


            return true;
        }
        public static Tiff Read(String fileName = @"D:\myMultipageFile.tif")
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

                Console.WriteLine("{0} directories in {1} using the NumberOfDirectories() method",
                    numberOfDirectories, image.FileName());

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
