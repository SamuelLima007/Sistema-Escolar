using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoScores.Data;
using ProjetoScores.Domain.Models;
using ProjetoScores.Domain.ViewModels;

namespace ProjetoScores.Domain.Interfaces
{
    public interface ISubjectController
    {
        Task<ActionResult<Subject>> GetSubjectByIdAsync(int id);
        Task<ActionResult<Subject>> AddSubjectAsync([FromServices] EscolaDataContext context, [FromBody] CreateSubjectViewModel model);
        Task<ActionResult<bool>> UpdateSubjectAsync(int id, [FromBody] Subject Subject);
        Task<ActionResult<bool>> DeleteSubjectAsync(int id);
    }
}