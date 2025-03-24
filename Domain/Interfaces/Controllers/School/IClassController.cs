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
    public interface IClassController
    {
        public Task<IActionResult> GetClassByIdAsync([FromServices] EscolaDataContext context, [FromRoute] int id);
        Task<IActionResult> AddClassAsync([FromServices] EscolaDataContext context, [FromBody] CreateClassViewModel model);
        Task<IActionResult> UpdateClassAsync([FromServices] EscolaDataContext context, [FromRoute] int id, [FromBody] Class classentity);
        Task<IActionResult> DeleteClassAsync([FromServices] EscolaDataContext context, [FromRoute] int id);
    }
}