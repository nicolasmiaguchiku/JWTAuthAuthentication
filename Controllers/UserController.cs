using Microsoft.AspNetCore.Mvc;
using JWTAuthAuthentication.Models;
using JWTAuthAuthentication.Services;
using JWTAuthAuthentication.Interfaces;
using JWTAuthAuthentication.Validations;

namespace JWTAuthAuthentication.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("teste")]
        public IActionResult Teste()
        {
            return Ok("Hello World");
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser newUser)
        {

            var report = await _userServices.CreateUser(newUser);
            if (report.Message == "Usuario criado com sucesso")
            {
                return Ok(report);
            }
            else
            {
                return BadRequest(report);
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin credentials)
        {
            var user = await _userServices.AuthenticateUser(credentials.Email, credentials.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Email ou senha incorretos" });
            }

            var token = TokenService.GenerateToken(user);
            return Ok(new { token });

        }
    }
}
