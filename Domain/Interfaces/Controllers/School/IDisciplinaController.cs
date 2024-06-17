using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
  
        public interface IDisciplinaController
    {
        Task<ActionResult<Disciplina>> GetDisciplinaByIdAsync(int id);
        Task<ActionResult<Disciplina>> AddDisciplinaAsync([FromServices] EscolaDataContext context,[FromBody] CreateDisciplinaViewModel model);
        Task<ActionResult<bool>> UpdateDisciplinaAsync(int id, [FromBody] Disciplina Disciplina);
        Task<ActionResult<bool>> DeleteDisciplinaAsync(int id);
    }
 
}