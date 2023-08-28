using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Data;
using ProjectApi.Models.DTO;
using ProjectApi.Models.Entities;
using ProjectApi.Services;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportImageController : ControllerBase
    {
        private readonly ProjectDatabaseContext _db;
        private readonly IMapper _mapper;
        private readonly IManageImage _iManageImage;

        public ReportImageController(ProjectDatabaseContext db, IMapper mapper, IManageImage iManageImage)
        {
            _db = db;
            _mapper = mapper;
            _iManageImage = iManageImage;
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

        [HttpGet]
        [Route("downloadfile")]
        public async Task<IActionResult> DownloadFile(string FileName)
        {
            var result = await _iManageImage.DownloadFile(FileName);
            return File(result.Item1, result.Item2, result.Item2);
        }

        // POST api/<ReportImageController>
        [HttpPost]
        [Route("uploadfile")]
        public async Task<IActionResult> UploadFile(IFormFile _IFormFile)
        {
            var result = await _iManageImage.UploadFile(_IFormFile);
            return Ok(result);
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
