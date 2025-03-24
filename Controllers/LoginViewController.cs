using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoScores.Data;
using ProjetoScores.Domain.Interfaces;
using ProjetoScores.Domain.ViewModels;
using ProjetoScores.Repository;
using ProjetoScores.WebUi.Services;

namespace ProjetoScores.WebUi.Controllers
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

        [HttpGet("TLogin/student")]
        public async Task<ActionResult> Logar()
        {
            return View("Login", new UserLoginViewModel());
        }

        [HttpPost("TLogin/Student")]
        public async Task<ActionResult> LoginStudentAsync(UserLoginViewModel student)
        {
           
            
            var Autenticado = await _logincontroller.LoginStudentAsync(student);

            if (Autenticado != null)
            {
               var user = _context.Students.FirstOrDefault(x => x.Email == student.Email);
               student.Name = user.Name;
              

                return await _inicioviewcontroller.Inicio(student);
            }

            TempData["FailureMessage"] = "Erro: Usuario ou password estão incorretos!";

            return View("Login");
        }
    }
}