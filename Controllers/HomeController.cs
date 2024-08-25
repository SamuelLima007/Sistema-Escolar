using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoNotas.Attributes;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Controllers
{

    public class HomeController : Controller
    {
        private readonly IAlunoService _alunoService;
        private readonly EscolaDataContext _context;


        public HomeController(IAlunoService alunoService, EscolaDataContext context)
        {
            _alunoService = alunoService;
            _context = context;

        }

        [HttpGet("/")]
        public IActionResult Get()
        {
            return View("Index", new CreateAlunoViewModel());
        }

        [HttpPost("/")]
        public async Task<IActionResult> Registro(CreateAlunoViewModel model)
        {
            if (model.Senha.Length < 8)
            {
                TempData["FailureMessage"] = "Erro: Senha deve conter 8 dígitos!";
                return View("Index");
            }

            if (model != null)
            {
                var aluno = _context.Alunos.FirstOrDefault(x => x.Email == model.Email);
                if (aluno != null)
                {
                    TempData["FailureMessage"] = "Erro: Email já cadastrado!";
                    return View("Index");
                }
                await _alunoService.AddAlunoAsync(model);
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso!";
                return View("Index");
            }

            TempData["FailureMessage"] = "Houve um erro no cadastro!";
            return View("Index");
        }
    }
}