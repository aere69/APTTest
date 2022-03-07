using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Endpoint
{
    public class CSVContext : DbContext
    {
        public DbSet<CSVRecord> CSVRecords { get; set; }
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; }

        public CSVContext() { }

        //Configure EF to create Sqlite database file
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=aptcsv.db");
    }

    public class CSVRecord
    {
        public int CSVRecordId { get; set; }
        public int SortCode { get; set; }
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public double Amount { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string FileName { get; set; }
        public double TotalAmount { get; set; }
        public List<CSVRecord> PostDetails { get; set; }
    }

}
