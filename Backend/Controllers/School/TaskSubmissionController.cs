using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces.Services.School;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.School
{
    [ApiController]
    [Route("taskssubmitted")]
    [Authorize(Roles = "School_Admin, Super_Admin, Teacher")]

    public class TaskSubmissionController : ControllerBase
    {
        private readonly ITaskSubmissionService _tasksubmissionService;
        public TaskSubmissionController(ITaskSubmissionService tasksubmissionService)
        {
            _tasksubmissionService = tasksubmissionService;
        }

        [HttpGet("{studentId}/{taskId}")]
        public async Task<ActionResult<TaskSubmission>> GetTaskSubmissionByIdAsync([FromRoute] int studentId, [FromRoute] int taskId)
        {
            var loggedId = User.GetUserLoggedId();
            var loggedRole = User.GetUserLoggedRole();
            var response = await _tasksubmissionService.GetTaskSubmittedByIdAsync(studentId, taskId, loggedId, loggedRole);
            if (response.Data == null && response.Errors.Contains("Forbidden")) return Forbid();
            if (response.Data == null && response.Result == false) return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TaskSubmission>> AddTaskSubmissionAsync([FromBody] CreateSubmittedTaskViewModel model)
        {
            try
            {
                var response = await _tasksubmissionService.AddTaskSubmittedAsync(model);
                //if (response.Data.Name == model.Name && response.Result == false) return Conflict(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{studentId}/{taskId}")]
        public async Task<ActionResult<bool>> UpdateTaskSubmissionAsync(int studentId, int taskId, [FromBody] CreateSubmittedTaskViewModel model)
        {
            var loggedId = User.GetUserLoggedId();
            var loggedRole = User.GetUserLoggedRole();
            try
            {
                var response = await _tasksubmissionService.UpdateTaskSubmittedAsync(studentId, taskId, model, loggedId, loggedRole);
                if (response.Data == null) return NotFound(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }


        [Authorize(Roles = "School_Admin, Super_Admin")]
        [HttpDelete("{studentId}/{taskId}")]
        public async Task<ActionResult<bool>> DeleteTaskSubmissionAsync(int studentId, int taskId)
        {

            var loggedId = User.GetUserLoggedId();
            var loggedRole = User.GetUserLoggedRole();
            try
            {
                var response = await _tasksubmissionService.DeleteTaskSubmittedAsync(studentId, taskId, loggedId, loggedRole);
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