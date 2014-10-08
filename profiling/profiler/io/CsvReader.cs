using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace profiler.io
{
    public class CsvReader
    {
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
    }

    public class DataRecord
    {
        //Should have properties which correspond to the Column Names in the file
        //i.e. CommonName,FormalName,TelephoneCode,CountryCode
        public String Id { get; set; }
        public String X { get; set; }
        public String Y { get; set; }
        public String Intensity { get; set; }
    }
}
