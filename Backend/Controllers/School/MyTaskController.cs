using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Domain.Interfaces.Controllers.School;
using ProjetoNotas.Domain.Interfaces.Services.School;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;

namespace ProjetoNotas.Controllers.School
{
    [ApiController]
    [Route("v1/mytasks")]
    public class MyTaskController : ControllerBase, IMyTaskController
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
         
            var Nmytask = await _mytaskService.AddMyTaskAsync(mytask);
            return CreatedAtAction(nameof(AddMyTaskAsync), new { id = Nmytask.MyTaskId }, Nmytask);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMyTaskAsync(int id, [FromBody] CreateMyTaskViewModel mytask)
        {
            var Updated = await _mytaskService.UpdateMyTaskAsync(id, mytask);
            if (Updated == false) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMyTaskAsync(int id)
        {
            var Deleted = await _mytaskService.DeleteMyTaskAsync(id);
            if (Deleted == false) return NotFound();
                
            return NoContent();
        }
    }
}