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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Report>> GetReports()
        {
            return Ok(_db.Reports.ToList());
        }

        [HttpGet("{id: int}", Name = "GetReport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Report> GetReport(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            
            var report = _db.Reports.FirstOrDefault(x => x.Id == id);
            
            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        [HttpPost]
        public ActionResult<Report> CreateReport([FromBody]Report reportDTO)
        {
            if (reportDTO == null || !ModelState.IsValid)
            {
                return BadRequest("The data is missing or invalid");
            }
            if (reportDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            _db.Reports.Add(reportDTO);
            _db.SaveChanges();

            return CreatedAtRoute("GetReport", new {id = reportDTO.Id}, reportDTO);
        }

        [HttpDelete("{id: int}", Name = "DeleteReport")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteReport(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var report = _db.Reports.FirstOrDefault(p => p.Id == id);
            if (report == null)
            {
                return NotFound();
            }
            _db.Reports.Remove(report);
            _db.SaveChanges();
            
            return NoContent();
        }

        [HttpPut("{id: int}", Name = "UpdateReportPut")]
        public IActionResult UpdateReport(int id, [FromBody]Report reportDTO)
        {
            if (reportDTO == null || reportDTO.Id != id)
            {
                return BadRequest("Invalid data or ID in the request");
            }
            _db.Reports.Update(reportDTO);
            _db.SaveChanges();

            return NoContent();

        }

        [HttpPatch("{id: int}", Name = "UpdateReportPatch")]
        public IActionResult UpdatePartialReport(int id, JsonPatchDocument<Report> reportDTO)
        {
            if (reportDTO == null || id == 0)
            {
                return BadRequest();
            }

            var report = _db.Reports.FirstOrDefault(p => p.Id == id);
            if (report == null)
            {
                return BadRequest();
            }

            reportDTO.ApplyTo(report, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Reports.Update(report);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
