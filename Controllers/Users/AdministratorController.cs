using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoScores.Attributes;
using ProjetoScores.Data;
using ProjetoScores.Domain.Interfaces;
using ProjetoScores.Domain.Models;
using ProjetoScores.Domain.ViewModels;

namespace ProjetoScores.WebUi.Controllers
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
        public async Task<ActionResult<Administrator>> AddAdministratorAsync([FromServices] EscolaDataContext context, [FromBody] CreateAdministratorViewModel model)
        {
            await _administratorService.AddAdministratorAsync(context, model);
            return Ok();
        }

        [HttpPut("v1/updateadmin/{id}")]
        public async Task<ActionResult<bool>> UpdateAdministratorAsync(int id, [FromBody] Administrator administrator)
        {
            if (!await _administratorService.UpdateAdministratorAsync(id, administrator))
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpDelete("v1/deleteadmin/{id}")]
        public async Task<ActionResult<bool>> DeleteAdministratorAsync(int id)
        {
            if (!await _administratorService.DeleteAdministratorAsync(id))
            {
                return NotFound();
            }
            return Ok(true);
        }
    }
}