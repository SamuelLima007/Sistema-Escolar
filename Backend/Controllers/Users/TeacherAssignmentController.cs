using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Interfaces.Controllers.Users;
using Backend.Domain.Interfaces.Services.Users;
using Backend.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Users
{
     [ApiController]
    [Route("teacherassignments")]
    public class TeacherAssignmentController : ControllerBase, ITeacherAssignmentController
    {
         private readonly ITeacherAssignmentService _teacherassignmentService;
        public TeacherAssignmentController(ITeacherAssignmentService tasksubmissionService)
        {
            _teacherassignmentService = tasksubmissionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherAssignment>> GetTeacherAssignmentByIdAsync(TeacherAssignment model)
        {
            var tasksubmitted = await _teacherassignmentService.GetTeacherAssignmentByIdAsync(model);
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

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateTeacherAssignmentAsync([FromBody] TeacherAssignment model)
        {
            var Updated = await _teacherassignmentService.UpdateTeacherAssignmentAsync(model);
            if (Updated == false) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTeacherAssignmentAsync([FromBody] TeacherAssignment model)
        {
            var Deleted = await _teacherassignmentService.DeleteTeacherAssignmentAsync(model);
            if (Deleted == false) return NotFound();

            return Ok();
        }
    }
}