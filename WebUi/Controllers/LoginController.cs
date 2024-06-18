using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.Models;
using ProjetoNotas.Repository;
using ProjetoNotas.WebUi.Services;

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

        [HttpPost("login/Aluno")]
        public async Task<ActionResult<dynamic>> LoginAlunoAsync([FromBody] UserLoginViewModel user)
        {
            var aluno = await _loginrepository.LoginAlunoAsync(user.Email, user.Senha);
            if (aluno == null)
            {
                return BadRequest("Usuario ou senha estão incorretos");
            }
            var token = _tokenservice.GenerateToken(aluno);
            aluno.Senha = "";
            return new
            {
                usuario = aluno,
                token = token
            };
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