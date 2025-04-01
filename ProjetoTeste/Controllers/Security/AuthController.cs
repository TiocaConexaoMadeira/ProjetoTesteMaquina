using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.Repositories.Security;
using ProjetoTeste.DTO.Security;   
using ProjetoTeste.Model.Security;

namespace ProjetoTeste.Controllers.Security
{

    //[Route("api/Security/[controller]")]
    [Route("api/Security/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthRepository _repository;
        private IConfiguration _configuration;
        public AuthController(AuthRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        /// <summary>
        /// Rota anônima para realizar o login
        /// </summary>
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            if (login == null || string.IsNullOrEmpty(login.Usuario) || string.IsNullOrEmpty(login.Senha))
            {
                return BadRequest("Usuário e senha são obrigatórios.");
            }

            var usuario = _repository.ConsultaPeloLogin(login.Usuario, login.Senha);
            if (usuario == null)
                return Unauthorized("Usuário ou senha inválidos!");

            return Ok("Login bem-sucedido!");
        }
    }
}