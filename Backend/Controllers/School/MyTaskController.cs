using Backend.Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ProjetoNotas.Domain.Interfaces.Services.School;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;

namespace ProjetoNotas.Controllers.School
{
    [ApiController]
    [Route("tasks")]
    [Authorize(Roles = "School_Admin, Super_Admin, Teacher")]
    public class MyTaskController : ControllerBase
    {
        private readonly IMyTaskService _mytaskService;
        public MyTaskController(IMyTaskService mytaskService)
        {
            _mytaskService = mytaskService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MyTask>> GetMyTaskByIdAsync(int id)
        {
            try
            {
                var loggedRole = User.GetUserLoggedRole();
                var loggedId = User.GetUserLoggedId();
                var response = await _mytaskService.GetMyTaskByIdAsync(id, loggedRole, loggedId);
                if (response.Data == null && response.Result == false) return NotFound(response);
                return Ok(response);
            }

            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddMyTaskAsync([FromBody] CreateMyTaskViewModel model)
        {
            try
            {

                var loggedId = User.GetUserLoggedId();
                var response = await _mytaskService.AddMyTaskAsync(model, loggedId);
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMyTaskAsync(int id, [FromBody] CreateMyTaskViewModel model)
        {
            try
            {
                var loggedRole = User.GetUserLoggedRole();
                var loggedId = User.GetUserLoggedId();
                var response = await _mytaskService.UpdateMyTaskAsync(id, model, loggedRole, loggedId);
                if (response.Data == null) return NotFound(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMyTaskAsync(int id)
        {

            var loggedRole = User.GetUserLoggedRole();
            var loggedId = User.GetUserLoggedId();
            try
            {
                var response = await _mytaskService.DeleteMyTaskAsync(id, loggedRole, loggedId);
                if (response.Data == null) return NotFound(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }
    }
}