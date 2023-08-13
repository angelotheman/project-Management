using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Data;
using ProjectApi.Models;
using ProjectApi.Models.DTO;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ReportController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // POST : api/ReportApi/addReport
        [HttpPost("addReport")]
        public IActionResult CreateReport([FromBody] ReportInputDTO reportInput)
        {
            if (reportInput == null)
            {
                return BadRequest("Invalid Data");
            }

            // Map ReportInputDTO with automapper
            var report = _mapper.Map<ReportInputDTO, Report>(reportInput);

            // Generate IssueID and set current Date
            report.IssueId = GenerateUniqueIssue();

            // Set the category of the report
            var category = _db.Category.Find(reportInput.CategoryId);

            // Set the category of the report
            report.Category = category;

            _db.Report.Add(report);
            _db.SaveChanges();

            return Ok(report);
        }

        private string GenerateUniqueIssue()
        {
            int issueIdLength = 7;
            string issueId = $"REPORT-{GenerateRandomAlphanumericString(issueIdLength)}";

            while (_db.Report.Any(x => x.IssueId == issueId))
            {
                issueId = $"REPORT-{GenerateRandomAlphanumericString(issueIdLength)}";
            }

            return issueId;
        }



        // This code generates the random characters from the alphanumeric table
        private string GenerateRandomAlphanumericString(int length)
        {
            const string alphanumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(alphanumericChars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // GET : api/ReportApi/{issueId}
        [HttpGet("{issueId}")]
        public IActionResult GetReportByIssueId(string issueId)
        {
            // Retrieve the report by its IssueId
            var report = _db.Report.FirstOrDefault(x => x.IssueId == issueId);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }
        /**
          * Great an action method (endpoint) for getting all categories.
          * This category would be a list (select list) of Id's and their names
          fid efdsiwie the LORD is my shepherd I shall not want
        */
        
        // GET : api/ReportApi/categories
        [HttpGet("Categories")]
        public IActionResult GetCategories()
        {
            var categories = _db.Category.ToList();
            return Ok(categories);
        }
    }
}
