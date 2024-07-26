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
        //[Authorize]
        public async Task<IActionResult> Register([FromBody] UserDTO model)
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
                return StatusCode(500, $"Erro ao efetuar login: {ex.Message}");
            }
        }

        [HttpPut("Edit/{id}")]
        [Authorize]
        public async Task<IActionResult> EditUser(int id, [FromBody] UserDTO model)
        {
            try
            {
                await _userService.EditUser(id, model);
                return Ok("Usuário editado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao editar usuário: {ex.Message}");
            }
        }

        [HttpDelete("Delete/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok("Usuário deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar usuário: {ex.Message}");
            }
        }

        [HttpGet("GetById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter usuário: {ex.Message}");
            }
        }
    }
}
