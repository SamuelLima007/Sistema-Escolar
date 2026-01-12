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

    public class SubjectController : ControllerBase, ISubjectController
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("v1/getsubject/{id}")]
        public async Task<ActionResult<Subject>> GetSubjectByIdAsync(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPost("v1/addsubject")]
        public async Task<ActionResult<Subject>> AddSubjectAsync([FromBody] CreateSubjectViewModel model)
        {
            var subject = await _subjectService.AddSubjectAsync(model);
            return Ok();
        }

        [HttpPut("v1/updatesubject/{id}")]
        public async Task<ActionResult<bool>> UpdateSubjectAsync(int id, [FromBody] CreateSubjectViewModel subject)
        {
            var Updated = await _subjectService.UpdateSubjectAsync(id, subject);
            if (Updated == false) return NotFound();

            return Ok();
        }

        [HttpDelete("v1/deletesubject/{id}")]
        public async Task<ActionResult<bool>> DeleteSubjectAsync(int id)
        {
            var Deleted = await _subjectService.DeleteSubjectAsync(id);
            if (Deleted == false) return NotFound();

            return Ok();
        }
    }
}