using System;
using System.Collections.Generic;
using BitMiracle.LibTiff.Classic;
using profiler.io;
using CsvReader = profiler.io.CsvReader;


namespace profiler
{
    class Program
    {
        static void Main(string[] args)
        {
           var reader = new CsvReader();
           List<DataRecord> readCsvList = reader.ReadCsvList(@"E:\spots_snr_3_SD_2.2_coords _test.csv");

            foreach (var dataRecord in readCsvList)
            {
                Console.WriteLine(String.Format("dataRecord.id = {0}   dataRecord.X = {1}   dataRecord.Y = {2}   dataRecord.Intensity = {3} \n", dataRecord.Id, dataRecord.X, dataRecord.Y, dataRecord.Intensity));
            }
            


            using (Tiff image = Tiff.Open(@"E:\myMultipageFile.tif", "r"))
            {
                if (image == null)
                    return;

                bool subDirectory = image.SetSubDirectory(0);
                bool directory = image.SetDirectory(0);
                bool isTiled = image.IsTiled();
                string fileName = image.FileName();
                bool lastDirectory = image.LastDirectory();

                short numberOfDirectories = image.NumberOfDirectories();
                int numberOfStrips = image.NumberOfStrips();
                int numberOfTiles = image.NumberOfTiles();

                System.Console.Out.WriteLine("{0} directories in {1} using the NumberOfDirectories() method", numberOfDirectories, image.FileName());

                int dircount = 0;
                do
                {
                    dircount++;
                } while (image.ReadDirectory());

                System.Console.Out.WriteLine("{0} directories in {1} using iterator", dircount, image.FileName());
            }
        }
    }
}