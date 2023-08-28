using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Data;
using ProjectApi.Models.DTO;
using ProjectApi.Models.Entities;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportImageController : ControllerBase
    {
        private readonly ProjectDatabaseContext _db;
        private readonly IMapper _mapper;

        public ReportImageController(ProjectDatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        
        // GET: api/<ReportImageController>
        [HttpGet]
        public IActionResult GetAllImages()
        {
            var images = _db.ReportImages.ToList();
            var imagesDTO = _mapper.Map<List<ReportImageDTO>>(images);

            return Ok(imagesDTO);
        }

        // GET api/<ReportImageController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var image = _db.ReportImages.SingleOrDefault(x => x.ImageId == id);
            var imageDTO = _mapper.Map<ReportImageDTO>(image);

            return Ok(imageDTO);
        }

        // POST api/<ReportImageController>
        [HttpPost("addImage")]
        public IActionResult AddImage([FromBody] CreateReportImageDTO reportImageDTO)
        {
            var reportImage = _mapper.Map<ReportImage>(reportImageDTO);
            reportImage.CreatedAt = DateTime.Now;
            reportImage.CreatedBy = "Admin";
            reportImage.IsDeleted = false;
            reportImage.UpdatedAt = DateTime.Now;
            reportImage.UpdatedBy = "Admin";

            _db.ReportImages.Add(reportImage);
            _db.SaveChanges();

            return Ok(reportImage);
        }

        // PUT api/<ReportImageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReportImageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
