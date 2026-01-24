using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;

namespace ProjetoNotas.WebUi.Controllers
{
    [ApiController]
    [Route("subjects")]
    //[Authorize(Roles = "School_Admin, Super_Admin")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubjectByIdAsync(int id)
        {
            var response = await _subjectService.GetSubjectByIdAsync(id);
            if (response.Data == null && response.Result == false) return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Subject>> AddSubjectAsync([FromBody] CreateSubjectViewModel model)
        {
            try
            {
                var response = await _subjectService.AddSubjectAsync(model);
                if (response.Data.Name == model.Name && response.Result == false) return Conflict(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateSubjectAsync(int id, [FromBody] CreateSubjectViewModel model)
        {
            try
            {
                var response = await _subjectService.UpdateSubjectAsync(id, model);
                if (response.Data == null) return NotFound(response);
                else if (response.Data.Name == model.Name && response.Result == false) return Conflict(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteSubjectAsync(int id)
        {
            try
            {
                var response = await _subjectService.DeleteSubjectAsync(id);
                if (response.Data == null && response.Result == false) return NotFound(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}