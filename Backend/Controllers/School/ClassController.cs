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
    public class ClassController : ControllerBase, IClassController
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }


     
        [Authorize(Roles = "Admin")]
        [HttpGet("v1/getclass/{id}")]
        public async Task<IActionResult> GetClassByIdAsync(int id)
        {
           var classentity = await _classService.GetClassByIdAsync(id);
            if (classentity == null)
                return NotFound();

            return Ok(classentity);
        }

        [HttpPost("v1/addclass")]
        public async Task<IActionResult> AddClassAsync(CreateClassViewModel model)
        {
           var classentity = await _classService.AddClassAsync(model);
            return CreatedAtAction(nameof(AddClassAsync), new { id = classentity.ClassId }, classentity);
        }

        [HttpPut("v1/updateclass/{id}")]
        public async Task<IActionResult> UpdateClassAsync(int id, Class classentity)
        {
            var Updated = await _classService.UpdateClassAsync(id, classentity);
            if (Updated == false) return NotFound();

            return NoContent();
        }

        [HttpDelete("v1/deleteclass/{id:int}")]
        public async Task<IActionResult> DeleteClassAsync(int id)
        {
            var Deleted = await _classService.DeleteClassAsync(id);
            if (Deleted == false) return NotFound();
                
            return NoContent();
        }
    }
}
