using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoScores.Domain.ViewModels;
using ProjetoScores.Repository;
using ProjetoScores.ViewModels;

namespace ProjetoScores.WebUi.Controllers
{


    public class InicioViewController : Controller
    {
        [HttpGet("Inicio")]
        public async Task<ActionResult> Inicio(UserLoginViewModel student)
        {
            
            return View("/Views/Home/Home.cshtml", student);
        }
    }
}