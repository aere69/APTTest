using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoint
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        // GET: api/<PostsController>

        /// <summary>
        /// Return a List or Posts
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Returns a list of all the posts (postId,fielName,totalAmount).
        /// </remarks>
        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
            using (CSVContext db = new CSVContext())
            {
                var result = db.Posts.ToList();
                return result;
            }
        }

        // GET api/<PostsController>/5

        /// <summary>
        /// Creates csv file from database for a given postId
        /// </summary>
        /// <param name="id">postId</param>
        /// <returns>path to csv file</returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string result;
            List<CSVExport> details = new List<CSVExport>();

            using (CSVContext db = new CSVContext())
            {
                //Get Post File Name
                var fileName = db.Posts.Where(p => p.PostId == id).FirstOrDefault().FileName;
                //Get records for File Name
                var records = db.CSVRecords.Where(r => r.PostId == id).ToList();

                //Convert Records to Details for CsvHelper(CsvWriter)
                foreach(CSVRecord r in records)
                {
                    details.Add(new CSVExport
                    {
                        SortCode = r.SortCode,
                        AccountNumber = r.AccountNumber,
                        Amount = r.Amount,
                        Reference = r.Reference,
                        Name = r.Name
                    });
                }

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "./Uploads", fileName);

                using (StreamWriter sw = new StreamWriter(filePath, false, new UTF8Encoding(true)))
                using (CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                    cw.WriteHeader<CSVExport>();
                    cw.NextRecord();
                    foreach (CSVExport d in details)
                    {
                        cw.WriteRecord<CSVExport>(d);
                        cw.NextRecord();
                    }
                }

                result = filePath;
            }

            return result;
        }
    }
}
