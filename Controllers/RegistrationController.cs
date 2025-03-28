using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoScores.Attributes;
using ProjetoScores.Data;
using ProjetoScores.Domain.Interfaces;
using ProjetoScores.Domain.ViewModels;
using ProjetoScores.Models;
using ProjetoScores.ViewModels;

namespace ProjetoScores.Controllers
{

    public class CadastroController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly EscolaDataContext _context;


        public CadastroController(IStudentService studentService, EscolaDataContext context)
        {
            _studentService = studentService;
            _context = context;

        }

        [HttpGet("/")]
        public IActionResult Get()
        {
            return View("/Views/Home/Cadastro.cshtml", new CreateStudentViewModel());
        }

        [HttpPost("/")]
        public async Task<IActionResult> Registro(CreateStudentViewModel model)
        {
            if (model.Password.Length < 8)
            {
                TempData["FailureMessage"] = "Erro: Password deve conter 8 dígitos!";
                return View("/Views/Home/Register.cshtml");
            }

            if (model != null)
            {
                var student = _context.Students.FirstOrDefault(x => x.Email == model.Email);
                if (student != null)
                {
                    TempData["FailureMessage"] = "Erro: Email já cadastrado!";
                    return View("/Views/Home/Register.cshtml");
                }
                await _studentService.AddStudentAsync(model);
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso!";
                return View("/Views/Home/Register.cshtml");
            }

            TempData["FailureMessage"] = "Houve um erro no Cadastro!";
            return View("/Views/Home/Register.cshtml");
        }
    }
}