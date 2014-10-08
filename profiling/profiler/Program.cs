using BitMiracle.LibTiff.Classic;


namespace profiler
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Tiff image = Tiff.Open(@"E:\storm_data\test.tif", "r"))
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
