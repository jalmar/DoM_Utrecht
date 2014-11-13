using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace profiler.io
{
    public class CsvData
    {
        public static void WriteToDisk(String fileName, String headerList, List<String> dataList)
        {
//            convertToDataRecords(dataList);

            using (var sw = new StreamWriter(fileName))
            {
                CsvConfiguration configuration = new CsvConfiguration();

                CsvWriter csvWriter = new CsvWriter(sw);

                csvWriter.WriteRecords(dataList);
            }

        }
        public List<List<DataRecord> > ReadCsvLists(List<String> groundTruthList)
        {
            var recordsLists = new List<List<DataRecord>>();

            foreach (string groundTruth in groundTruthList)
            {
                recordsLists.Add(ReadCsvList(groundTruth));
            }

            return recordsLists;
        }
        public List<DataRecord> ReadCsvList(String groundTruth)
        {

            using (var streamReader = new StreamReader(groundTruth))
            {
                var reader = new CsvHelper.CsvReader(streamReader);

                //CSVReader will now read the whole file into an enumerable
                IEnumerable<DataRecord> records = reader.GetRecords<DataRecord>();

                //First 5 records in CSV file will be printed to the Output Window
                foreach (DataRecord record in records.Take(5))
                {
                    Debug.Print("{0} {1}, {2}, {3}", record.Id, record.X, record.Y, record.Intensity);
                }

                return records.ToList();
            }
        }

        private List<DataRecord> convertToDataRecords(List<String> dataList)
        {
            List<DataRecord> dataRecords = new List<DataRecord>();
            foreach (string s in dataList)
            {
                s.Split(',');

                dataRecords.Add(new DataRecord(){});
            }

            return dataRecords;
        }
    }

    public class DataRecord
    {
        //Should have properties which correspond to the Column Names in the file
        //i.e. CommonName,FormalName,TelephoneCode,CountryCode
        public String Id { get; set; }
        public String X { get; set; }
        public String Y { get; set; }
        public String Z { get; set; }
        public String Intensity { get; set; }
    }
}
