using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BEP
{
    public class CSVContext : DbContext
    {
        public DbSet<CSVRecord> CSVRecords { get; set; }

        public string DbPath { get; }

        public CSVContext() 
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "aptcsv.db");
        }

        //Configure EF to create Sqlite database file
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class CSVRecord
    {
        public int CSVRecordId { get; set; }
        public int SortCode { get; set; }
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public double Amount { get; set; }
    }
}

