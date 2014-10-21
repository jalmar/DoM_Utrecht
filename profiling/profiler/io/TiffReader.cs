using System;
using BitMiracle.LibTiff.Classic;

namespace profiler.io
{
    class TiffReader
    {
        public static void Read(String fileName = @"D:\myMultipageFile.tif")
        {
            using (Tiff image = Tiff.Open(fileName, "r"))
            {
                if (image == null)
                    return;

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
            }
        }
    }
}
