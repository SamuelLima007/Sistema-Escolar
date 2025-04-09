using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Attributes;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.InfraStructure.Interfaces;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Controllers
{
    [ApiController]

    [Authorize(Roles = "Admin")]

    public class TeacherController : ControllerBase, ITeacherController
    {
        private readonly ITeacherService _teacherservice;

        public TeacherController (ITeacherService teacherservice)
        {
            _teacherservice = teacherservice;
        }
       

        [HttpGet("v1/")]
        public async Task<IActionResult> GetTeacherAsync([FromRoute] int id)
        {
           
            var teacher = await _teacherservice.GetTeacherByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpPost("v1/teacheres/c")]

        public async Task<IActionResult> AddTeacherAsync([FromBody] CreateTeacherViewModel model, int id)
        {
            var teacher = await _teacherservice.AddTeacherAsync(model, id);
            return Ok(teacher);
        }

        [HttpPut("v1/teacheres/{id:int}")]
        public async Task<IActionResult> UpdateTeacherAsync([FromRoute] int id, [FromBody] CreateTeacherViewModel teacher)
        {
           var Updated = await _teacherservice.UpdateTeacherAsync(id, teacher);
            if (Updated == false) return NotFound();

            return NoContent();
        }

        [HttpDelete("v1/teacheres/{id:int}")]
        public async Task<IActionResult> DeleteTeacherAsync([FromRoute] int id)
        {
            var Deleted = await _teacherservice.DeleteTeacherAsync(id);
            if (Deleted == false) return NotFound();
                
            return NoContent();
        }

    }
}
