
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.Repository;


namespace ProjetoNotas.WebUi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly LoginRepository _loginrepository;
        private readonly ITokenService _tokenservice;

        public LoginController(LoginRepository loginrepository, ITokenService tokenservice)
        {
            _loginrepository = loginrepository;
            _tokenservice = tokenservice;
        }

        [HttpPost("Login/Aluno")]
        public async Task<ActionResult> LoginAlunoAsync([FromBody] UserLoginViewModel user)
        {
            try
            {
                var aluno = await _loginrepository.LoginAlunoAsync(user.Email, user.Senha);
                if (aluno == null)
                {
                    return NotFound("Aluno não encontrado");
                }

                var token = _tokenservice.GenerateToken(aluno);
                return Ok(token);

            }
            catch (Exception)
            {

                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpPost("login/Professor")]
        public async Task<ActionResult<dynamic>> LoginProfessorAsync([FromBody] UserLoginViewModel user)
        {
            var professor = await _loginrepository.LoginProfessorAsync(user.Email, user.Senha);
            if (professor == null)
            {
                return BadRequest("Usuario ou senha estão incorretos");
            }
            var token = _tokenservice.GenerateToken(professor);
            professor.Senha = "";
            return new
            {
                professor = professor,
                token = token
            };
        }

        [HttpPost("login/Admin")]
        public async Task<ActionResult<dynamic>> LoginAdministradorAsync([FromBody] UserLoginViewModel user)
        {
            var administrador = await _loginrepository.LoginAdminAsync(user.Email, user.Senha);
            if (administrador == null)
            {
                return BadRequest("Usuario ou senha estão incorretos");
            }
            var token = _tokenservice.GenerateToken(administrador);
            administrador.Senha = "";
            return new
            {
                administrador = administrador,
                token = token
            };
        }

    }
}