using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Data;
using ProjectApi.Models.DTO;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ProjectDatabaseContext _db;
        private readonly IMapper _mapper;
        public CategoryController(ProjectDatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _db.Categories.ToList();

            var categoriesDTO = _mapper.Map<List<CreateCategoryDTO>>(categories);

            return Ok(categoriesDTO);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult GetCategoryId(int categoryId)
        {
            var category = _db.Categories.SingleOrDefault(c => c.CategoryId == categoryId);

            /*
            if (category == null)
            {
                return NotFound();
            }*/

            var categoryDTO = _mapper.Map<CreateCategoryDTO>(category);

            return Ok(categoryDTO);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
