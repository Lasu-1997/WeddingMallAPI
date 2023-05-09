using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingMallAPI.Models;
using WeddingMallAPI.Repository;

namespace WeddingMallAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository serviceRepository;

        public ServiceController(IServiceRepository _serviceRepository)
        {
            serviceRepository = _serviceRepository;
        }
        [HttpGet]
        [Route("Getall")]
        public async Task<ActionResult<IEnumerable<Service>>> GetAll()
        {
            try
            {
                return Ok(await serviceRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }

        }
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Service>> GetById(int id)
        {
            try
            {
                return Ok(await serviceRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }

        }
        [HttpPost]
        public async Task<ActionResult<Service>> Add(Service service)
        {
            try
            {
                var result = await serviceRepository.Add(service);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error creating new service record");
            }
        }
    }
}
