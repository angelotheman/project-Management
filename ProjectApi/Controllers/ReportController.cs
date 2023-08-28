using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Data;
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
        [HttpGet("GetById/{id}")]
        public IActionResult GetReportById(int id)
        {
            var report = _db.Reports.SingleOrDefault(x => x.ReportId == id);
            var reportDTO = _mapper.Map<ReportDTO>(report);


            return Ok(reportDTO);
        }

        // GET /api/<ReportController>/{issueid}
        [HttpGet("GetByIssueId/{issueId}")]
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

            /**
            while (_db.Reports.Any(x => x.IssueId == issueId))
            {
                issueId = $"REPORT-{GenerateRandomAlphanumericString(issueIdLength)}";
            }*/

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
        [HttpPost("addReport")]
        public IActionResult CreateReport([FromBody] CreateReportDTO createReportDTO)
        {
            var report = _mapper.Map<Report>(createReportDTO);
            report.IssueId = GenerateUniqueIssue();
            report.IsDeleted = false;
            report.CreatedAt = DateTime.UtcNow;
            report.CreatedBy = "Admin";
            report.UpdatedAt = DateTime.UtcNow;
            report.UpdatedBy = "Admin";

            _db.Reports.Add(report);
            _db.SaveChanges();

            // Save Report Status
            var reportStatus = new ReportStatus
            {
                ReportId = report.ReportId,
                StatusId = 1,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                IsDeleted = false,
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "Admin"
            };

            _db.ReportStatuses.Add(reportStatus);
            _db.SaveChanges();

            // Report Image Object
            var reportImage = new ReportImage
            {
                ReportId = report.ReportId,
                ImageName = createReportDTO.Image.ImageName,
                ImageUrl = createReportDTO.Image.ImageUrl,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                IsDeleted = false,
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "Admin"
            };

            _db.ReportImages.Add(reportImage);
            _db.SaveChanges();
            

            var reportDTO = _mapper.Map<ReportDTO>(report);
            return Ok(reportDTO);
        }

        // UPDATE status
        [HttpPost("addReportStatus")]

        public IActionResult UpdateReportStatus([FromBody] ReportStatusDTO reportStatusDTO)
        {

            var reportStatus = new ReportStatus
            {
                ReportId = reportStatusDTO.ReportId,
                StatusId = reportStatusDTO.StatusId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                IsDeleted = false,
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "Admin"
            };

            _db.ReportStatuses.Add(reportStatus);
            _db.SaveChanges();

            return Ok("Successful");
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
