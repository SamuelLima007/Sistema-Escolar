using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Interfaces.Controllers.School;
using Backend.Domain.Interfaces.Services.School;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.School
{
      [ApiController]
    [Route("taskssubmitted")]

    public class TaskSubmissionController : ControllerBase, ITaskSubmissionController
    {
            private readonly ITaskSubmissionService _tasksubmissionService;
        public TaskSubmissionController(ITaskSubmissionService tasksubmissionService)
        {
            _tasksubmissionService = tasksubmissionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskSubmission>> GetTaskSubmissionByIdAsync(int studentId, int taskId)
        {
            var tasksubmitted = await _tasksubmissionService.GetTaskSubmittedByIdAsync(studentId, taskId);
            if (tasksubmitted == null)
            {
                return NotFound();
            }
            return Ok(tasksubmitted);
        }

        [HttpPost]
        public async Task<ActionResult<TaskSubmission>> AddTaskSubmissionAsync([FromBody] CreateSubmittedTaskViewModel model)
        {
            var subject = await _tasksubmissionService.AddTaskSubmittedAsync(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateTaskSubmissionAsync(int studentId, int taskId, [FromBody] CreateSubmittedTaskViewModel model)
        {
            var Updated = await _tasksubmissionService.UpdateTaskSubmittedAsync(studentId, taskId, model);
            if (Updated == false) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTaskSubmissionAsync(int studentId,int mytaskId)
        {
            var Deleted = await _tasksubmissionService.DeleteTaskSubmittedAsync(studentId, mytaskId);
            if (Deleted == false) return NotFound();

            return Ok();
        }
    }
}