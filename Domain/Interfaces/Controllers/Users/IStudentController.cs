// IStudentController.cs
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Data;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IStudentController
    {
        Task<ActionResult<Student>> GetStudentByIdAsync(int id);
        Task<ActionResult<Student>> AddStudentAsync([FromBody] CreateStudentViewModel model);
        Task<ActionResult<bool>> UpdateStudentAsync(int id, [FromBody] CreateStudentViewModel student);
        Task<ActionResult<bool>> DeleteStudentAsync(int id);
    }
}