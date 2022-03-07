using System;
using System.Linq;

namespace BEP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Story 1 - Back End Processor!");

            var db = new CSVContext();
            
            try
            {
                Console.WriteLine($"Database path: {db.DbPath}.");

                //Create
                BEPProcessor theProcessor = new BEPProcessor(db);
                int records = theProcessor.Process("C:\\APT\\Sample CSV.csv");

                Console.WriteLine($"Records added to Database : {records}.");

                //Review Inserts
                Console.WriteLine("Records in Database");
                foreach (var CSVRecord in db.CSVRecords)
                {
                    Console.WriteLine($"{CSVRecord.SortCode}, {CSVRecord.AccountNumber}, {CSVRecord.Name}, {CSVRecord.Reference}, {CSVRecord.Amount}");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error Processing FIle.\n {ex.Message}");
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
