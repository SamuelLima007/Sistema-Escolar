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
            var myTask = await _mytaskService.GetMyTaskByIdAsync(id);
            if (myTask == null)
                return NotFound();

            return Ok(myTask);
        }

        [HttpPost]
        public async Task<ActionResult> AddMyTaskAsync([FromBody] CreateMyTaskViewModel mytask)
        {

            var task = await _mytaskService.AddMyTaskAsync(mytask);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMyTaskAsync(int id, [FromBody] CreateMyTaskViewModel mytask)
        {
            var Updated = await _mytaskService.UpdateMyTaskAsync(id, mytask);
            if (Updated == false) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMyTaskAsync(int id)
        {
            var Deleted = await _mytaskService.DeleteMyTaskAsync(id);
            if (Deleted == false) return NotFound();
            return Ok();
        }
    }
}