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
    public class ClasseController : ControllerBase, IClasseController
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("v1/getclasse/{id}")]
        public async Task<IActionResult> GetClasseByIdAsync([FromServices] EscolaDataContext context, [FromRoute] int id)
        {
            try
            {
                var classe = await context.Classes.FirstOrDefaultAsync(x => x.ClasseId == id);
                if (classe == null)
                {
                    return NotFound();
                }
                return Ok(classe);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpPost("v1/addclasse")]
        public async Task<IActionResult> AddClasseAsync([FromServices] EscolaDataContext context, [FromBody] CreateClasseViewModel model)
        {
            try
            {
                var classe = new Classe()
                {
                    Serie = model.Serie,
                    Turma = model.Turma
                };
                await context.Classes.AddAsync(classe);
                await context.SaveChangesAsync();
                return Created($"v1/classes{classe.ClasseId}", await context.SaveChangesAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpPut("v1/updateclasse/{id}")]
        public async Task<IActionResult> UpdateClasseAsync([FromServices] EscolaDataContext context, [FromRoute] int id, [FromBody] Classe classe)
        {
            try
            {
                var Nclasse = await context.Classes.FirstOrDefaultAsync(x => x.ClasseId == id);
                if (Nclasse == null)
                {
                    return NotFound();
                }

                Nclasse.Serie = classe.Serie;
                Nclasse.Turma = classe.Turma;
                context.Classes.Update(Nclasse);
                await context.SaveChangesAsync();
                return Ok(Nclasse);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpDelete("v1/deleteclasse/{id:int}")]
        public async Task<IActionResult> DeleteClasseAsync([FromServices] EscolaDataContext context, [FromRoute] int id)
        {
            try
            {
                var classe = await context.Classes.FirstOrDefaultAsync(x => x.ClasseId == id);
                if (classe == null)
                {
                    return NotFound();
                }
                context.Classes.Remove(classe);
                await context.SaveChangesAsync();
                return Ok(classe);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }
    }
}
