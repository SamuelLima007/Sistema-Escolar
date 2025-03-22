using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.Repository;
using ProjetoNotas.WebUi.Services;

namespace ProjetoNotas.WebUi.Controllers
{

    public class LoginViewController : Controller
    {
        private readonly LoginController _logincontroller;
        private readonly InicioViewController _inicioviewcontroller;

        private readonly EscolaDataContext _context;

  

        public LoginViewController(LoginController logincontroller, InicioViewController inicioviewcontroller, EscolaDataContext context)
        {
            _logincontroller = logincontroller;
            _inicioviewcontroller = inicioviewcontroller;
            _context = context;
           
         

        }

        [HttpGet("TLogin/aluno")]
        public async Task<ActionResult> Logar()
        {
            return View("Login", new UserLoginViewModel());
        }

        [HttpPost("TLogin/Aluno")]
        public async Task<ActionResult> LoginAlunoAsync(UserLoginViewModel aluno)
        {
           
            
            var Autenticado = await _logincontroller.LoginAlunoAsync(aluno);

            if (Autenticado != null)
            {
               var user = _context.Alunos.FirstOrDefault(x => x.Email == aluno.Email);
               aluno.Nome = user.Nome;
              

                return await _inicioviewcontroller.Inicio(aluno);
            }

            TempData["FailureMessage"] = "Erro: Usuario ou senha estão incorretos!";

            return View("Login");
        }
    }
}