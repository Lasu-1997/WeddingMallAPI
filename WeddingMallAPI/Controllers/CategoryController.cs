using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingMallAPI.Models;
using WeddingMallAPI.Repository;

namespace WeddingMallAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
        [HttpGet]
        [Route("Getall")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            try
            {
                return Ok(await categoryRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await categoryRepository.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<Category>> Add(Category category)
        {
            try
            {
                var result = await categoryRepository.Add(category);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error creating new category record");
            }
        }
    }
}
