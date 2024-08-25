using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.Repository;

namespace ProjetoNotas.WebUi.Controllers
{


    public class InicioViewController : Controller
    {
        [HttpGet("Inicio")]
        public async Task<ActionResult> Inicio()
        {
            return View("/Views/Home/Inicio.cshtml");
        }
    }
}