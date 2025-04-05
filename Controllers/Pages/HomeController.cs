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
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.WebUi.Controllers
{


    public class HomeController : Controller
    {
        [HttpGet("Homepage")]
        public async Task<ActionResult> Homepage(UserLoginViewModel student)
        {
            
            return View("/Views/Home/Home.cshtml", student);
        }
    }
}