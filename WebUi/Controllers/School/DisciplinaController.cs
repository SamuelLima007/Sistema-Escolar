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
    [Authorize(Roles = "Admin")]
    public class DisciplinaController : ControllerBase, IDisciplinaController
    {
        private readonly IDisciplinaService _disciplinaService;

        public DisciplinaController(IDisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }

        [HttpGet("v1/getdisciplina/{id}")]

        public async Task<ActionResult<Disciplina>> GetDisciplinaByIdAsync(int id)
        {
            var disciplina = await _disciplinaService.GetDisciplinaByIdAsync(id);
            if (disciplina == null)
            {
                return NotFound();
            }
            return Ok(disciplina);
        }


        [HttpPost("v1/adddisciplina")]
        public async Task<ActionResult<Disciplina>> AddDisciplinaAsync([FromServices] EscolaDataContext context, [FromBody] CreateDisciplinaViewModel model)
        {
            var disciplina = await _disciplinaService.AddDisciplinaAsync(context, model);
            return CreatedAtAction(nameof(GetDisciplinaByIdAsync), new { id = disciplina.DisciplinaId }, disciplina);
        }

        [HttpPut("v1/updatedisciplina/{id}")]
        public async Task<ActionResult<bool>> UpdateDisciplinaAsync(int id, [FromBody] Disciplina disciplina)
        {
            if (!await _disciplinaService.UpdateDisciplinaAsync(id, disciplina))
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpDelete("v1/deletedisciplina/{id}")]
        public async Task<ActionResult<bool>> DeleteDisciplinaAsync(int id)
        {
            if (!await _disciplinaService.DeleteDisciplinaAsync(id))
            {
                return NotFound();
            }
            return Ok(true);
        }
    }
}