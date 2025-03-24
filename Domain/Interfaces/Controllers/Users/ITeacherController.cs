using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoScores.Data;
using ProjetoScores.Models;
using ProjetoScores.ViewModels;

namespace ProjetoScores.InfraStructure.Interfaces
{
    public interface ITeacherController
    {
        public Task<IActionResult> GetTeacherAsync([FromServices] EscolaDataContext context, [FromRoute] int id);
        Task<IActionResult> AddTeacherAsync([FromServices] EscolaDataContext context, [FromBody] CreateTeacherViewModel model);
        Task<IActionResult> UpdateTeacherAsync([FromServices] EscolaDataContext context, [FromRoute] int id, [FromBody] Teacher teacher);
        Task<IActionResult> DeleteTeacherAsync([FromServices] EscolaDataContext context, [FromRoute] int id);
    }
}