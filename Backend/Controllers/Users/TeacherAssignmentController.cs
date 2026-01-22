using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Backend.Domain.Interfaces.Services.Users;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Users
{
    [ApiController]
    [Route("teacherassignments")]
    [Authorize(Roles = "School_Admin, Super_Admin")]
    public class TeacherAssignmentController : ControllerBase
    {
        private readonly ITeacherAssignmentService _teacherassignmentService;
        public TeacherAssignmentController(ITeacherAssignmentService tasksubmissionService)
        {
            _teacherassignmentService = tasksubmissionService;
        }

        [HttpGet("{teacherId}/{classId}/{subjectId}")]
        public async Task<ActionResult<TeacherAssignment>> GetTeacherAssignmentByIdAsync(int teacherId, int classId, int subjectId)
        {
            var tasksubmitted = await _teacherassignmentService.GetTeacherAssignmentByIdAsync(teacherId, classId, subjectId);
            if (tasksubmitted == null)
            {
                return NotFound();
            }
            return Ok(tasksubmitted);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherAssignment>> AddTeacherAssignmentAsync([FromBody] TeacherAssignment model)
        {
            var subject = await _teacherassignmentService.AddTeacherAssignmentAsync(model);
            return Ok();
        }

        [HttpPut("{teacherId}/{classId}/{subjectId}")]
        public async Task<ActionResult<bool>> UpdateTeacherAssignmentAsync(int teacherId, int classId, int SubjectId, [FromBody] CreateTeacherAssignmentViewModel model)
        {
            var Updated = await _teacherassignmentService.UpdateTeacherAssignmentAsync(teacherId, classId, SubjectId, model);
            if (Updated == false) return NotFound();
            return Ok();
        }

        [HttpDelete("{teacherId}/{classId}/{subjectId}")]
        public async Task<ActionResult<bool>> DeleteTeacherAssignmentAsync(int teacherId, int classId, int SubjectId)
        {
            var Deleted = await _teacherassignmentService.DeleteTeacherAssignmentAsync(teacherId, classId, SubjectId);
            if (Deleted == false) return NotFound();
            return Ok();
        }
    }
}