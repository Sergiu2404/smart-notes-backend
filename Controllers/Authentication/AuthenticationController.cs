using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using smart_notes_backend.Entities;
using smart_notes_backend.Models.Authentication;
using smart_notes_backend.Services.Authentication;
using System.Threading.Tasks;

namespace smart_notes_backend.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
    {
        public static User user = new();

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterDto request)
        {
            var user = await authenticationService.RegisterAsync(request);
            if (user == null)
            {
                return BadRequest("Username already existing");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginDto request)
        {
            var token = await authenticationService.LoginAsync(request);
            if (token == null)
            {
                return BadRequest("Invalid username or password");
            }
            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public IActionResult SecuredEndpoint()
        {
            return Ok("Authenticated");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("Admin Authenticated");
        }
    }
}
