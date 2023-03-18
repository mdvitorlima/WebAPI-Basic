using BasicAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
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
    }
}
