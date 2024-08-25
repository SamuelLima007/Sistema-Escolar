using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Attributes;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;

namespace ProjetoNotas.WebUi.Controllers
{
    [ApiController]
    [ApiKey]
    
    public class AdministradorController : ControllerBase, IAdministradorController
    {
        private readonly IAdministradorService _administradorService;

        public AdministradorController(IAdministradorService administradorService)
        {
            _administradorService = administradorService;
        }

        [HttpGet("v1/getadmin/{id}")]
       
        public async Task<ActionResult<Administrador>> GetAdministradorByIdAsync(int id)
        {
            var administrador = await _administradorService.GetAdministradorByIdAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }
            return Ok(administrador);
        }

        [HttpPost("v1/addadmin")]
        public async Task<ActionResult<Administrador>> AddAdministradorAsync([FromServices] EscolaDataContext context, [FromBody] CreateAdministradorViewModel model)
        {
            await _administradorService.AddAdministradorAsync(context, model);
            return Ok();
        }

        [HttpPut("v1/updateadmin/{id}")]
        public async Task<ActionResult<bool>> UpdateAdministradorAsync(int id, [FromBody] Administrador administrador)
        {
            if (!await _administradorService.UpdateAdministradorAsync(id, administrador))
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpDelete("v1/deleteadmin/{id}")]
        public async Task<ActionResult<bool>> DeleteAdministradorAsync(int id)
        {
            if (!await _administradorService.DeleteAdministradorAsync(id))
            {
                return NotFound();
            }
            return Ok(true);
        }
    }
}