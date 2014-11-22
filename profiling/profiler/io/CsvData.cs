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
        public static void WriteToDisk(String fileName, ushort[] dataList)
        {
            if (File.Exists(fileName))
                throw new WarningException(fileName + "is overwritten");

            using (var sw = new StreamWriter(fileName))
            {
                CsvWriter csvWriter = new CsvWriter(sw, new CsvConfiguration());

                for (int i = 0; i < dataList.LongLength / 4; i++)
                {
                    csvWriter.WriteField(dataList[4 * i]);
                    csvWriter.WriteField(dataList[4 * i + 1]);
                    csvWriter.WriteField(dataList[4 * i + 2]);
                    csvWriter.WriteField(dataList[4 * i + 3]);
                    csvWriter.NextRecord();
                }
            }
        }

        public static float[] ReadFluorophores(String fileName)
        {
            if(!File.Exists(fileName))
                throw new FileNotFoundException(fileName);

            CsvConfiguration configuration = new CsvConfiguration();

            configuration.HasHeaderRecord = false;
            configuration.TrimFields = true;

//            List<float[]> fluorophores = new List<float[]>();
            List<float> fluorophores = new List<float>();

            using (CsvReader reader = new CsvReader(new StreamReader(fileName), configuration))
            {
                IEnumerable<DataRecord> dataRecords = reader.GetRecords<DataRecord>();

                foreach (DataRecord dataRecord in dataRecords.ToList())
                {
                    fluorophores.AddRange(dataRecord.ToFloat());
                }
            }

            return fluorophores.ToArray();
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

        public float[] ToFloat()
        {
            return new[] {float.Parse(X), float.Parse(Y), float.Parse(Z), float.Parse(w)};
        }
    }
}
