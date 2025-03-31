using Core.Ports.In;
using Core.Ports.In.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.Data;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> AddUser(AddUserDto userDto)
        {
            string token = await _userService.AddUser(userDto);

            return Ok(new
            {
                Message = "El usuario se ha creado exitosamente.",
                Token = token
            });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto request)
        {
            string token = await _userService.LoginUser(request);

            return Ok(new
            {
                Message = "El usuario se ha logeado exitosamente",
                Token = token
            });
        }

    }
}
