// StudentController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Attributes;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.WebUi.Controllers
{
    [ApiController]


    [ApiKey]
    public class StudentController : ControllerBase, IStudentController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet("v1/getstudent/{id}")]

        public async Task<ActionResult<Student>> GetStudentByIdAsync(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("v1/addstudent")]
        public async Task<ActionResult<Student>> AddStudentAsync([FromBody] CreateStudentViewModel model)
        {

            var student = await _studentService.AddStudentAsync(model);
            return Ok(student);
        }


        [HttpPut("v1/updatestudent/{id}")]
        public async Task<ActionResult<bool>> UpdateStudentAsync(int id, [FromBody] CreateStudentViewModel student)
        {
            var Updated = await _studentService.UpdateStudentAsync(id, student);
            if (Updated == false) return NotFound();

            return NoContent();
        }

        [HttpDelete("v1/deletestudent/{id}")]
        public async Task<ActionResult<bool>> DeleteStudentAsync(int id)
        {
            var Deleted = await _studentService.DeleteStudentAsync(id);
            if (Deleted == false) return NotFound();
                
            return NoContent();
        }
    }
}