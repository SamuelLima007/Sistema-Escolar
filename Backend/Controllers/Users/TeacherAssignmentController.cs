using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    //[Authorize(Roles = "School_Admin, Super_Admin")]
    public class TeacherAssignmentController : ControllerBase
    {
        private readonly ITeacherAssignmentService _teacherassignmentService;
        public TeacherAssignmentController(ITeacherAssignmentService teacherassignmentService)
        {
            _teacherassignmentService = teacherassignmentService;
        }

        [HttpGet("{teacherId}/{classId}/{subjectId}")]
        public async Task<ActionResult<TeacherAssignment>> GetTeacherAssignmentByIdAsync(int teacherId, int classId, int subjectId)
        {
              try
            {
                var response = await _teacherassignmentService.GetTeacherAssignmentByIdAsync(teacherId, classId, subjectId);
                if (response.Data == null && response.Result == false) return NotFound(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TeacherAssignment>> AddTeacherAssignmentAsync([FromBody] TeacherAssignment model)
        {
     
             try
            {
                var response = await _teacherassignmentService.AddTeacherAssignmentAsync(model);
                if (response.Data.TeacherId == model.TeacherId && response.Data.ClassId == model.ClassId && response.Data.SubjectId == model.SubjectId && response.Result == false)
                {
                     return Conflict(response);
                }
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }

        [HttpPut("{teacherId}/{classId}/{subjectId}")]
        public async Task<ActionResult<bool>> UpdateTeacherAssignmentAsync(int teacherId, int classId, int SubjectId, [FromBody] CreateTeacherAssignmentViewModel model)
        {
         
             try
            {
                var response = await _teacherassignmentService.UpdateTeacherAssignmentAsync(teacherId, classId, SubjectId, model  );
                if (response.Data == null) return NotFound(response);
                else if (response.Data.TeacherId == model.TeacherId && response.Data.ClassId == model.ClassId && response.Data.SubjectId == model.SubjectId && response.Result == false)
                {
                     return Conflict(response);
                }
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }

        [HttpDelete("{teacherId}/{classId}/{subjectId}")]
        public async Task<ActionResult<bool>> DeleteTeacherAssignmentAsync(int teacherId, int classId, int SubjectId)
        {
              try
            {
                var response = await _teacherassignmentService.DeleteTeacherAssignmentAsync(teacherId, classId, SubjectId);
                if (response.Data == null && response.Result == false) return NotFound(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }
    }
}