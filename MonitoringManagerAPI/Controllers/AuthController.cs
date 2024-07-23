using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MonitoringManagerAPI.Domain.DTOs;
using MonitoringManagerAPI.Service.Authenticate;
using MonitoringManagerAPI.Service.Users;

namespace MonitoringManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticateService _authService;
        public AuthController(IUserService usersService,
            IAuthenticateService authenticate)
        {
            _userService = usersService;
            _authService = authenticate;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            try
            {     
                await _userService.Register(model); 

                return Ok("Usuário registrado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao registrar usuário: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            try
            {
                var token = _authService.Authenticate(model.Username, model.Password);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Error = ex.Message });
            }
        }

        [HttpGet("Teste")]
        [Authorize]
        public IActionResult teste()
        {
            try
            {
                return Ok("Funcionou");
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Error = ex.Message });
            }
        }

    }
}
