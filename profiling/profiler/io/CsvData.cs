using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;

namespace profiler.io
{
    public class CsvData
    {
        public static void WriteToDisk(String fileName, List<String> dataList)
        {
            if (File.Exists(fileName))
                throw new WarningException(fileName + "is overwritten");

            using (var sw = new StreamWriter(fileName))
            {
                CsvWriter csvWriter = new CsvWriter(sw);

                csvWriter.WriteRecords(dataList);
            }
        }

        public static IEnumerable<float> ReadFluorophores(String fileName)
        {
            if(!File.Exists(fileName))
                throw new FileNotFoundException(fileName);

            using (var streamReader = new StreamReader(fileName))
            {
                var reader = new CsvReader(streamReader);

                return reader.GetRecords<float>();
            }
        }
    }

    public class DataRecord
    {
        //Should have properties which correspond to the Column Names in the file
        //i.e. CommonName,FormalName,TelephoneCode,CountryCode
        public String X { get; set; }
        public String Y { get; set; }
        public String Z { get; set; }
        public String w { get; set; }
    }
}
