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

    public class SubmittedTaskController : ControllerBase
    {
        private readonly ISubmittedTaskService _submittedtaskService;
        public SubmittedTaskController(ISubmittedTaskService submittedtaskService)
        {
            _submittedtaskService = submittedtaskService;
        }

        [HttpGet("{studentId}/{taskId}")]
        public async Task<ActionResult<SubmittedTask>> GetSubmittedTaskByIdAsync([FromRoute] int studentId, [FromRoute] int taskId)
        {
            try
            {
                var loggedId = User.GetUserLoggedId();
                var loggedRole = User.GetUserLoggedRole();
                var response = await _submittedtaskService.GetSubmittedTaskByIdAsync(studentId, taskId, loggedId, loggedRole);
                if (response.Data == null && response.Errors.Contains("Forbidden")) return Forbid();
                if (response.Data == null && response.Result == false) return NotFound(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }

        [HttpPost]
        public async Task<ActionResult<SubmittedTask>> AddSubmittedTaskAsync([FromBody] CreateSubmittedTaskViewModel model)
        {
            try
            {
                var loggedRole = User.GetUserLoggedRole();
                var loggedId = User.GetUserLoggedId();
                var response = await _submittedtaskService.AddSubmittedTaskAsync(model, loggedRole, loggedId);
                //if (response.Data.Name == model.Name && response.Result == false) return Conflict(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }

        [HttpPut("{studentId}/{taskId}")]
        public async Task<ActionResult<bool>> UpdateSubmittedTaskAsync(int studentId, int taskId, [FromBody] CreateSubmittedTaskViewModel model)
        {
            var loggedId = User.GetUserLoggedId();
            var loggedRole = User.GetUserLoggedRole();
            try
            {
                var response = await _submittedtaskService.UpdateSubmittedTaskAsync(studentId, taskId, model, loggedId, loggedRole);
                if (response.Data == null) return NotFound(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }


        [Authorize(Roles = "School_Admin, Super_Admin")]
        [HttpDelete("{studentId}/{taskId}")]
        public async Task<ActionResult<bool>> DeleteSubmittedTaskAsync(int studentId, int taskId)
        {

            var loggedId = User.GetUserLoggedId();
            var loggedRole = User.GetUserLoggedRole();
            try
            {
                var response = await _submittedtaskService.DeleteSubmittedTaskAsync(studentId, taskId, loggedId, loggedRole);
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