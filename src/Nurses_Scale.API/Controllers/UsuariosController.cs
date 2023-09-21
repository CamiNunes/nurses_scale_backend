using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nurses_Scale.Application.Interfaces;
using Nurses_Scale.Application.Services;
using Nurses_Scale.Domain.Entities;

namespace Nurses_Scale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthService _authService;

        public UsuariosController(IUsuarioService usuarioService, IAuthService authService)
        {
            _usuarioService = usuarioService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var usuarios = _usuarioService.ObterTodosUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult Register(RegistrarUsuario registrarUsuario)
        {
            // Valide os dados do usuário, faça outras verificações necessárias.

            //var usuarioExistente = _usuarioService.ObterUsuarioPorNome(registrarUsuario.Email);
            //if (usuarioExistente.Result.Email != null)
            //{
            //    //throw new Exception("Usuário com o email " + registrarUsuario.Email + " já existe.");
            //    return Ok(new { message = "Usuário com o email " + registrarUsuario.Email + " já existe." });
            //}

            try
            {
                var usuarioCriado = _usuarioService.CriarUsuario(registrarUsuario);
                return Ok(new { message = "Usuário registrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao registrar o usuário: " + ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            var usuario = await _usuarioService.LoginAsync(login.Email, login.Senha);
            if (usuario == null)
            {
                return Unauthorized("Email ou senha inválidos."); // Autenticação falhou.
            }

            var token = _authService.GerarJwtToken(usuario.Email, usuario.UsuarioId);
            return Ok(new { token });
        }
    }
}
