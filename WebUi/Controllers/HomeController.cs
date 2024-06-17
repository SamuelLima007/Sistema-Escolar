using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Attributes;

namespace ProjetoNotas.Controllers
{
    [ApiController]
   
 

    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get()
        {

            try
            {
                return Ok("Hello World!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }
        
    }
}