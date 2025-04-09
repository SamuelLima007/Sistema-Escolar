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
    
    public class AdministratorController : ControllerBase, IAdministratorController
    {
        private readonly IAdministratorService _administratorService;

        public AdministratorController(IAdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        [HttpGet("v1/getadmin/{id}")]
       
        public async Task<ActionResult<Administrator>> GetAdministratorByIdAsync(int id)
        {
            var administrator = await _administratorService.GetAdministratorByIdAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }
            return Ok(administrator);
        }

        [HttpPost("v1/addadmin")]
        public async Task<ActionResult<Administrator>> AddAdministratorAsync([FromBody] CreateAdministratorViewModel model)
        {
            await _administratorService.AddAdministratorAsync(model);
            return Ok();
        }

        [HttpPut("v1/updateadmin/{id}")]
        public async Task<ActionResult<bool>> UpdateAdministratorAsync(int id, [FromBody] CreateAdministratorViewModel administrator)
        {
            var Updated = await _administratorService.UpdateAdministratorAsync(id, administrator);
            if (Updated == false) return NotFound();

            return NoContent();
        }

        [HttpDelete("v1/deleteadmin/{id}")]
        public async Task<ActionResult<bool>> DeleteAdministratorAsync(int id)
        {
            var Deleted = await _administratorService.DeleteAdministratorAsync(id);
            if (Deleted == false) return NotFound();
                
            return NoContent();
        }
    }
}