// IAlunoController.cs
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Data;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IAlunoController
    {
        Task<ActionResult<Aluno>> GetAlunoByIdAsync(int id);
        Task<ActionResult<Aluno>> AddAlunoAsync([FromServices] EscolaDataContext context,[FromBody] CreateAlunoViewModel model);
        Task<ActionResult<bool>> UpdateAlunoAsync(int id, [FromBody] Aluno aluno);
        Task<ActionResult<bool>> DeleteAlunoAsync(int id);
    }
}