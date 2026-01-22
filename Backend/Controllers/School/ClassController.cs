
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;


using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.RouteAttribute("class")]
    [Authorize(Roles = "School_Admin, Super_Admin")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassByIdAsync(int id)
        {
            var classentity = await _classService.GetClassByIdAsync(id);
            if (classentity == null)
                return NotFound();

            return Ok(classentity);
        }

        [HttpPost]
        public async Task<IActionResult> AddClassAsync([FromBody] CreateClassViewModel model)
        {
           try
            {
                 
             return Ok(await _classService.AddClassAsync(model));
           }
           catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassAsync(int id, Class classentity)
        {
            var Updated = await _classService.UpdateClassAsync(id, classentity);
            if (Updated == false) return NotFound();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteClassAsync(int id)
        {
            var Deleted = await _classService.DeleteClassAsync(id);
            if (Deleted == false) return NotFound();
            return Ok();
        }
    }
}
