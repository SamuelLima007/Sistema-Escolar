
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoScores.Domain.Interfaces;
using ProjetoScores.Domain.ViewModels;
using ProjetoScores.Models;
using ProjetoScores.Repository;


namespace ProjetoScores.WebUi.Controllers
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

        [HttpPost("Login/Student")]
        public async Task<ActionResult> LoginStudentAsync([FromBody] UserLoginViewModel user)
        {
            try
            {
                var student = await _loginrepository.LoginStudentAsync(user.Email, user.Password);
                if (student == null)
                {
                    return null;
                }

                var token = _tokenservice.GenerateToken(student);
                return Ok(token);

            }
            catch (Exception)
            {

                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpPost("login/Teacher")]
        public async Task<ActionResult<dynamic>> LoginTeacherAsync([FromBody] UserLoginViewModel user)
        {
            var teacher = await _loginrepository.LoginTeacherAsync(user.Email, user.Password);
            if (teacher == null)
            {
                return BadRequest("Usuario ou password estão incorretos");
            }
            var token = _tokenservice.GenerateToken(teacher);
            teacher.Password = "";
            return new
            {
                teacher = teacher,
                token = token
            };
        }

        [HttpPost("login/Admin")]
        public async Task<ActionResult<dynamic>> LoginAdministratorAsync([FromBody] UserLoginViewModel user)
        {
            var administrator = await _loginrepository.LoginAdminAsync(user.Email, user.Password);
            if (administrator == null)
            {
                return BadRequest("Usuario ou password estão incorretos");
            }
            var token = _tokenservice.GenerateToken(administrator);
            administrator.Password = "";
            return new
            {
                administrator = administrator,
                token = token
            };
        }

    }
}