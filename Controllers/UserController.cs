using Azure;
using BasicAPI.Entities;
using BasicAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _IUserService;

        public UserController(IUserService serv)
        {
            _IUserService = serv;
        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _IUserService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _IUserService.GetUserById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO user)
        {
            return Ok(await _IUserService.AddUser(user));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(User user)
        {
            return Ok(await _IUserService.UpdateUser(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            User user = await _IUserService.DeleteUser(id);

            if(user != null)
            {
                return NotFound(user);
            }

            return Ok(user);

        }

    }
}
