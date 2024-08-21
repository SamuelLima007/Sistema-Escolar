using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Attributes;
using ProjetoNotas.Data;
using ProjetoNotas.InfraStructure.Interfaces;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Controllers
{
    [ApiController]

    [Authorize(Roles = "Admin")]

    public class ProfessorController : ControllerBase, IProfessorController
    {

        [HttpGet("v1/")]
        public async Task<IActionResult> GetProfessorAsync([FromServices] EscolaDataContext context, [FromRoute] int id)
        {
            try
            {
                var professor = await context.Professores.FirstOrDefaultAsync(x => x.ProfessorId == id);

                if (professor == null)
                {
                    return NotFound();
                }

                return Ok(professor);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpPost("v1/professores/c")]

        public async Task<IActionResult> AddProfessorAsync([FromServices] EscolaDataContext context, [FromBody] CreateProfessorViewModel model)
        {
            try
            {
                var professor = new Professor()
                {
                    Nome = model.Nome,
                    Idade = model.Idade,
                    Email = model.Email,
                    Senha = model.Senha,
                    Classes = model.Classe
                };
                await context.Professores.AddAsync(professor);
                await context.SaveChangesAsync();
                return Created($"v1/professores{professor.ProfessorId}", await context.SaveChangesAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpPut("v1/professores/{id:int}")]
        public async Task<IActionResult> UpdateProfessorAsync([FromServices] EscolaDataContext context, [FromRoute] int id, [FromBody] Professor professor)
        {
            try
            {
                var Nprofessor = await context.Professores.FirstOrDefaultAsync(x => x.ProfessorId == id);
                if (Nprofessor == null)
                {
                    return NotFound();
                }

                Nprofessor.Nome = professor.Nome;
                Nprofessor.Idade = professor.Idade;


                context.Professores.Update(Nprofessor);
                await context.SaveChangesAsync();
                return Ok(Nprofessor);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpDelete("v1/professores/{id:int}")]
        public async Task<IActionResult> DeleteProfessorAsync([FromServices] EscolaDataContext context, [FromRoute] int id)
        {
            try
            {
                var professor = await context.Professores.FirstOrDefaultAsync(x => x.ProfessorId == id);
                if (professor == null)
                {
                    return NotFound();
                }
                context.Professores.Remove(professor);
                await context.SaveChangesAsync();


                return Ok(professor);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

    }
}
