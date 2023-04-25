using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleTasks.Data.Models.DTO;
using SimpleTasks.Services.UserService;

namespace SimpleTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO DTO)
        {
            try
            {
                await userService.Register(DTO);
                return Ok("New User has been register");
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO DTO)
        {
            try
            {
                var Token = await userService.Login(DTO);
                return Ok(Token);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }
    }
}
