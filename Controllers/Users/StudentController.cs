// StudentController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoScores.Attributes;
using ProjetoScores.Data;
using ProjetoScores.Domain.Interfaces;
using ProjetoScores.Models;
using ProjetoScores.ViewModels;

namespace ProjetoScores.WebUi.Controllers
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
        public async Task<ActionResult<Student>> AddStudentAsync([FromServices] EscolaDataContext context, [FromBody] CreateStudentViewModel model)
        {

            var student = await _studentService.AddStudentAsync(model);
            return Ok();
        }


        [HttpPut("v1/updatestudent/{id}")]
        public async Task<ActionResult<bool>> UpdateStudentAsync(int id, [FromBody] Student student)
        {
            if (!await _studentService.UpdateStudentAsync(id, student))
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpDelete("v1/deletestudent/{id}")]
        public async Task<ActionResult<bool>> DeleteStudentAsync(int id)
        {
            if (!await _studentService.DeleteStudentAsync(id))
            {
                return NotFound();
            }
            return Ok(true);
        }
    }
}