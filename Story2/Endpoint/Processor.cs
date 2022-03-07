using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoint
{
    public class Processor
    {
    }
    public class CSVDetails
    {
        public int SortCode { get; set; }
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public double Amount { get; set; }

    }

    public class BEPProcessor
    {
        List<CSVDetails> records;
        private CSVContext db;

        public BEPProcessor(CSVContext theDB)
        {
            db = theDB;
        }


        public int Process(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //records = csv.GetRecords<CSVDetails>();

                records = new List<CSVDetails>();
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var record = new CSVDetails
                    {
                        SortCode = csv.GetField<int>("Sort Code"),
                        AccountNumber = csv.GetField<int>("Account Number"),
                        Name = csv.GetField("Name"),
                        Reference = csv.GetField("Reference"),
                        Amount = double.Parse(csv.GetField("Amount").Substring(1, csv.GetField("Amount").Length - 1), NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-GB"))
                    };
                    records.Add(record);
                }
            }

            foreach (CSVDetails record in records)
            {
                db.Add(new CSVRecord
                {
                    SortCode = record.SortCode,
                    AccountNumber = record.AccountNumber,
                    Name = record.Name,
                    Reference = record.Reference,
                    Amount = record.Amount
                });
            }
            db.SaveChanges();

            return records.Count;
        }
    }

}
