using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Data;
using ProjectApi.Models;
using ProjectApi.Models.DTO;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ReportsApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        // POST: api/ReportsApi
        [HttpPost]
        public IActionResult CreateReport([FromBody] ReportInputDTO reportInput)
        {
            if(reportInput == null)
            {
                return BadRequest("Invalid report data.");
            }

            // Assign the UserId based on authentication status
            int userId = IsUserAuthenticated() ? GetAuthenticatedUserId() : -1; // Or any default value I choose for the user

            // Map the ReportDTO to the Report model
            var report = new Report
            {
                FaultDescription = reportInput.FaultDescription,
                ImageUrl = reportInput.ImageUrl,
                FaultCategory = reportInput.FaultCategory,
                Location = reportInput.Location,
                FaultStatus = Status.Pending, // Setting the current state to pending
                Created_At = DateTime.UtcNow, // Setting the current date to now
                UserId = userId // Using the retrieved userId or default
            };

            // Save the report to database
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetReportByIssueId), new { issueId = report.IssueId }, report);
        }

        // Method to determine if user is authenticated
        private bool IsUserAuthenticated()
        {
            return HttpContext.User.Identity?.IsAuthenticated ?? false;
        }

        // Helper method to retrieve the userId from claims
        private int GetAuthenticatedUserId()
        {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            return -1;
        }

        // GET: api/ReportsApi/{issueid}
        [HttpGet("{issueId}")]
        public IActionResult GetReportByIssueId(string issueId)
        {
            // Retrieve the report by its IssueId
            var report = _db.Reports.FirstOrDefault(x =>  x.IssueId == issueId);

            if (report != null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        // GET: api/ReportsApi/dashboard
        [HttpGet("dashboard")]
        [Authorize] // This requires authentication to access dashboard
        public IActionResult Dashboard()
        {
            int authenticatedUserId = GetAuthenticatedUserId();
            var userReports = _db.Reports.Where(r => r.UserId == authenticatedUserId).ToList();

            // Returning a list of report summaries for the user's dashboard
            var reportSummaries = userReports.Select(r => new
            {
                r.IssueId,
                CustomerName = $"{r.User.FirstName} {r.User.LastName}", // Customer Name
                r.Created_At,
                r.FaultStatus
            }).ToList();

            return Ok(reportSummaries);
        }
    }
}
