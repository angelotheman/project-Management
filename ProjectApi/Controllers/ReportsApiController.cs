using System.Security.Claims;
using Microsoft.AspNetCore.JsonPatch;
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

            // Check if user is authenticated
            bool isAuthenticated = HttpContext.User.Identity.IsAuthenticated;

            // Assign the UserId based on authentication status
            int userId = isAuthenticated ? GetAuthenticatedUserId() : -1; // Or any default value I choose for the user

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
    }
}
