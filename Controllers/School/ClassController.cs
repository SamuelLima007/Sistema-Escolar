using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoScores.Attributes;
using ProjetoScores.Data;
using ProjetoScores.InfraStructure.Interfaces;
using ProjetoScores.Models;
using ProjetoScores.ViewModels;

namespace ProjetoScores.Controllers
{
    [ApiController]
    public class ClassController : ControllerBase, IClassController
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("v1/getclass/{id}")]
        public async Task<IActionResult> GetClassByIdAsync([FromServices] EscolaDataContext context, [FromRoute] int id)
        {
            try
            {
                var classentity = await context.Classs.FirstOrDefaultAsync(x => x.ClassId == id);
                if (classentity == null)
                {
                    return NotFound();
                }
                return Ok(classentity);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpPost("v1/addclass")]
        public async Task<IActionResult> AddClassAsync([FromServices] EscolaDataContext context, [FromBody] CreateClassViewModel model)
        {
            try
            {
                var classentity = new Class()
                {
                    Grade = model.Grade,
                    Section = model.Section
                };
                await context.Classs.AddAsync(classentity);
                await context.SaveChangesAsync();
                return Created($"v1/classs{classentity.ClassId}", await context.SaveChangesAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpPut("v1/updateclass/{id}")]
        public async Task<IActionResult> UpdateClassAsync([FromServices] EscolaDataContext context, [FromRoute] int id, [FromBody] Class classentity)
        {
            try
            {
                var Nclass = await context.Classs.FirstOrDefaultAsync(x => x.ClassId == id);
                if (Nclass == null)
                {
                    return NotFound();
                }

                Nclass.Grade = classentity.Grade;
                Nclass.Section = classentity.Section;
                context.Classs.Update(Nclass);
                await context.SaveChangesAsync();
                return Ok(Nclass);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpDelete("v1/deleteclass/{id:int}")]
        public async Task<IActionResult> DeleteClassAsync([FromServices] EscolaDataContext context, [FromRoute] int id)
        {
            try
            {
                var classentity = await context.Classs.FirstOrDefaultAsync(x => x.ClassId == id);
                if (classentity == null)
                {
                    return NotFound();
                }
                context.Classs.Remove(classentity);
                await context.SaveChangesAsync();
                return Ok(classentity);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }
    }
}
