
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;


using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.RouteAttribute("class")]
    //[Authorize(Roles = "School_Admin, Super_Admin")]
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
            var response = await _classService.GetClassByIdAsync(id);
            if (response.Data == null && response.Result == false) return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddClassAsync([FromBody] CreateClassViewModel model)
        {
            try
            {
                var response = await _classService.AddClassAsync(model);
                if (response.Data.Grade == model.Grade && response.Result == false) return Conflict(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassAsync(int id, CreateClassViewModel model)
        {
            try
            {
                var response = await _classService.UpdateClassAsync(id, model);
                if (response.Data == null) return NotFound(response);
                else if (response.Data.Grade == model.Grade && response.Result == false) return Conflict(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteClassAsync(int id)
        {
            try
            {
                var response = await _classService.DeleteClassAsync(id);
                if (response.Data == null) return NotFound(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
