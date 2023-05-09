using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingMallAPI.Repository;
using WeddingMallAPI.Models;

namespace WeddingMallAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        [HttpGet]
        [Route("Getall")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                return Ok(await userRepository.GetUsers());
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var result = await userRepository.GetUserById(id);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                var createUser = await userRepository.AddUser(user);

                return Ok(createUser);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new user record");
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                var updateUsers = await userRepository.UpdateUser(user);
                return Ok(updateUsers);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating user record");
            }
        }
        [HttpDelete]
        [Route("Remove")]
        public JsonResult RemoveUser(int id)
        {
            userRepository.DeleteUser(id);
            return new JsonResult("Remove successfully!");
        }

    }
}
