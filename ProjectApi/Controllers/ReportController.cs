using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Models.DTO;
using ProjectApi.Models.Entities;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ProjectDatabaseContext _db;
        private readonly IMapper  _mapper;
        public ReportController(ProjectDatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // GET: api/<ReportController>
        [HttpGet]
        public IActionResult GetAllReports()
        {
            var reports = _db.Reports.ToList();
            var reportsDTO = _mapper.Map<List<ReportDTO>>(reports);
            return Ok(reportsDTO);
        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public IActionResult GetReportById(int id)
        {
            var report = _db.Reports.SingleOrDefault(x => x.ReportId == id);
            var reportDTO = _mapper.Map<ReportDTO>(report);


            return Ok(reportDTO);
        }

        // GET /api/<ReportController>/{issueid}
        [HttpGet("{issueId}")]
        public IActionResult GetReportByIssueId(string issueId)
        {
            var report = _db.Reports.SingleOrDefault(x => x.IssueId == issueId);
            var reportDTO = _mapper.Map<ReportDTO>(report);

            return Ok(reportDTO);
        }

        // Generate IssueId automatically
        private string GenerateUniqueIssue()
        {
            int issueIdLength = 7;
            string issueId = $"REPORT-{GenerateRandomAlphanumericString(issueIdLength)}";

            while (_db.Reports.Any(x => x.IssueId == issueId))
            {
                issueId = $"REPORT-{GenerateRandomAlphanumericString(issueIdLength)}";
            }

            return issueId;
        }

        private string GenerateRandomAlphanumericString(int length)
        {
            const string alphanumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var random = new Random();

            return new string(Enumerable.Repeat(alphanumericChars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // POST api/<ReportController>
        [HttpPost]
        public IActionResult CreateReport([FromBody] CreateReportDTO createReportDTO)
        {
            var report = _mapper.Map<Report>(createReportDTO);
            report.IssueId = GenerateUniqueIssue();
            report.IsDeleted = false;
            report.CreatedAt = DateTime.UtcNow;
            report.CreatedBy = "Admin";
            report.UpdatedAt = DateTime.UtcNow;
            report.UpdatedBy = "Admin";

            /* Report Image object
            var reportImage = new ReportImage();
            reportImage.ReportId = report.ReportId;
            reportImage.ImageName = 
            */

            _db.Reports.Add(report);
            _db.SaveChanges();

            var reportDTO = _mapper.Map<ReportDTO>(report);
            return Ok(reportDTO);
        }

        // PUT api/<ReportController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
