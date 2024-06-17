using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Data;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.InfraStructure.Interfaces
{
    public interface IClasseController
    {
        public Task<IActionResult> GetClasseByIdAsync([FromServices] EscolaDataContext context, [FromRoute] int id);
        

       

        Task<IActionResult> AddClasseAsync([FromServices] EscolaDataContext context, [FromBody] CreateClasseViewModel model);
        

      
        Task<IActionResult> UpdateClasseAsync([FromServices] EscolaDataContext context, [FromRoute] int id, [FromBody] Classe classe);
       

       
        Task<IActionResult> DeleteClasseAsync([FromServices] EscolaDataContext context, [FromRoute] int id);
    }
}