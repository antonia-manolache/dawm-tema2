using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private UserService userService { get; set; }
        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("/register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            userService.Register(registerDto);
            return Ok();
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDto payload)
        {
            return Ok();
        }
    }
}
