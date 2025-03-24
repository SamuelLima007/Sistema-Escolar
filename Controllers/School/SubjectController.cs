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
    [Authorize(Roles = "Admin")]
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
        public async Task<ActionResult<Subject>> AddSubjectAsync([FromServices] EscolaDataContext context, [FromBody] CreateSubjectViewModel model)
        {
            var subject = await _subjectService.AddSubjectAsync(context, model);
            return CreatedAtAction(nameof(GetSubjectByIdAsync), new { id = subject.SubjectId }, subject);
        }

        [HttpPut("v1/updatesubject/{id}")]
        public async Task<ActionResult<bool>> UpdateSubjectAsync(int id, [FromBody] Subject subject)
        {
            if (!await _subjectService.UpdateSubjectAsync(id, subject))
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpDelete("v1/deletesubject/{id}")]
        public async Task<ActionResult<bool>> DeleteSubjectAsync(int id)
        {
            if (!await _subjectService.DeleteSubjectAsync(id))
            {
                return NotFound();
            }
            return Ok(true);
        }
    }
}