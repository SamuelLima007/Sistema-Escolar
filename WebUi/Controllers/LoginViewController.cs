using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.Repository;

namespace ProjetoNotas.WebUi.Controllers
{

    public class LoginViewController : Controller
    {
        private readonly LoginController _logincontroller;
        private readonly InicioViewController _inicioviewcontroller;

        public LoginViewController(LoginController logincontroller, InicioViewController inicioviewcontroller)
        {
            _logincontroller = logincontroller;
            _inicioviewcontroller = inicioviewcontroller;

        }

        [HttpGet("TLogin/aluno")]
        public async Task<ActionResult> Logar()
        {
            var user = new UserLoginViewModel();
            return View("Login", user);
        }

        [HttpPost("TLogin/Aluno")]
        public async Task<ActionResult> LoginAlunoAsync(UserLoginViewModel aluno)
        {
            var Autenticado = await _logincontroller.LoginAlunoAsync(aluno);

            if (Autenticado != null)
            {
                return await _inicioviewcontroller.Inicio();
            }

            TempData["FailureMessage"] = "Erro: Usuario ou senha estão incorretos!";

            return View("Login");
        }
    }
}