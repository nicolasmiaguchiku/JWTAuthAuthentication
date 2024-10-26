using Microsoft.AspNetCore.Mvc;
using JWTAuthAuthentication.Models;
using JWTAuthAuthentication.Services;
using JWTAuthAuthentication.Interfaces;
using Microsoft.AspNetCore.Authorization;


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

        [HttpGet]
        [Route("Teste")]
        public IActionResult Teste()
        {
            return Ok("Hello World");
        }

        [HttpPost]
        [Route("CreateUser")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser newUser)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { Message = "Necessária a autenticação" });
            }

            if (!User.IsInRole("admin"))
            {
                return Unauthorized(new { Message = "Usuário não autorizado" });
            }

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


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLogin credentials)
        {
            var user = await _userServices.AuthenticateUser(credentials.Email, credentials.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Email ou senha incorretos" });
            }

            var token = TokenService.GenerateToken(user);

            return Ok(new
            {
                name = user.Name,
                role = user.Role,
                token
            });

        }
    }
}

