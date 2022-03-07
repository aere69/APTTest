using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionController : ControllerBase
    {
        private readonly ILogger<SubmissionController> _logger;

        public SubmissionController(ILogger<SubmissionController> logger)
        {
            _logger = logger;
        }

        // POST api/<SubmissionController>

        /// <summary>
        /// Process and Validate the file to be saved
        /// </summary>
        /// <param name="file">File to process</param>
        /// <returns></returns>
        /// <remarks>
        /// File must be csv.
        /// 
        /// Headers: Sort Code,Account Number,Name,Reference,Amount
        /// 
        /// Body : Sort Code = number
        ///        Account Number = number
        ///        Name = string
        ///        Reference = string
        ///        Amount = number
        ///
        /// </remarks>
        /// <response code="200">Ok. Returns the filename and lines processed</response>
        /// <response code="400">Request error</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(IFormFile file)
        {
            int processedRecords = 0;

            //process file content
            if (file == null)
                return BadRequest("No file provided");

            if (file.Length <= 0)
                return BadRequest("Empty file");

            //Strip out any path specifiers (ex: /../)
            var originalFileName = Path.GetFileName(file.FileName);

            //Create a unique file path
            var uniqueFileName = Path.GetRandomFileName();
            var uniqueFilePath = Path.Combine(Directory.GetCurrentDirectory(), "./Uploads", uniqueFileName);

            //Save the file to disk
            using (var stream = System.IO.File.Create(uniqueFilePath))
            {
                await file.CopyToAsync(stream);
            }

            //using (var db = new CSVContext())
            //{
            //    BEPProcessor theProcessor = new BEPProcessor(db);
            //    processedRecords = theProcessor.Process(uniqueFilePath);
            //}

            CSVContext db = new CSVContext();
            try
            {
                BEPProcessor theProcessor = new BEPProcessor(db);
                processedRecords = theProcessor.Process(uniqueFilePath);

            }
            catch (Exception ex)
            {
                return BadRequest($"Error Processing FIle.\n {ex.Message}");
            }
            finally
            {
                db.Dispose();
            }


            return Ok(new SubmissionResult { FileName = originalFileName, TotalLinesRead = processedRecords });
        }
    }
}
