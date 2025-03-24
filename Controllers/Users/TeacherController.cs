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

    [Authorize(Roles = "Admin")]

    public class TeacherController : ControllerBase, ITeacherController
    {

        [HttpGet("v1/")]
        public async Task<IActionResult> GetTeacherAsync([FromServices] EscolaDataContext context, [FromRoute] int id)
        {
            try
            {
                var teacher = await context.Teacheres.FirstOrDefaultAsync(x => x.TeacherId == id);

                if (teacher == null)
                {
                    return NotFound();
                }

                return Ok(teacher);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpPost("v1/teacheres/c")]

        public async Task<IActionResult> AddTeacherAsync([FromServices] EscolaDataContext context, [FromBody] CreateTeacherViewModel model)
        {
            try
            {
                var teacher = new Teacher()
                {
                    Name = model.Name,
                    Age = model.Age,
                    Email = model.Email,
                    Password = model.Password,
                    Classs = model.Class
                };
                await context.Teacheres.AddAsync(teacher);
                await context.SaveChangesAsync();
                return Created($"v1/teacheres{teacher.TeacherId}", await context.SaveChangesAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpPut("v1/teacheres/{id:int}")]
        public async Task<IActionResult> UpdateTeacherAsync([FromServices] EscolaDataContext context, [FromRoute] int id, [FromBody] Teacher teacher)
        {
            try
            {
                var Nteacher = await context.Teacheres.FirstOrDefaultAsync(x => x.TeacherId == id);
                if (Nteacher == null)
                {
                    return NotFound();
                }

                Nteacher.Name = teacher.Name;
                Nteacher.Age = teacher.Age;


                context.Teacheres.Update(Nteacher);
                await context.SaveChangesAsync();
                return Ok(Nteacher);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpDelete("v1/teacheres/{id:int}")]
        public async Task<IActionResult> DeleteTeacherAsync([FromServices] EscolaDataContext context, [FromRoute] int id)
        {
            try
            {
                var teacher = await context.Teacheres.FirstOrDefaultAsync(x => x.TeacherId == id);
                if (teacher == null)
                {
                    return NotFound();
                }
                context.Teacheres.Remove(teacher);
                await context.SaveChangesAsync();


                return Ok(teacher);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

    }
}
