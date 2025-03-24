// IStudentController.cs
using Microsoft.AspNetCore.Mvc;
using ProjetoScores.Data;
using ProjetoScores.Models;
using ProjetoScores.ViewModels;

namespace ProjetoScores.Domain.Interfaces
{
    public interface IStudentController
    {
        Task<ActionResult<Student>> GetStudentByIdAsync(int id);
        Task<ActionResult<Student>> AddStudentAsync([FromServices] EscolaDataContext context,[FromBody] CreateStudentViewModel model);
        Task<ActionResult<bool>> UpdateStudentAsync(int id, [FromBody] Student student);
        Task<ActionResult<bool>> DeleteStudentAsync(int id);
    }
}