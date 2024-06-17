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
    public interface IProfessorController
    {
         public Task<IActionResult> GetProfessorAsync([FromServices] EscolaDataContext context, [FromRoute] int id);
        

       

        Task<IActionResult> AddProfessorAsync([FromServices] EscolaDataContext context, [FromBody] CreateProfessorViewModel model);
        

      
        Task<IActionResult> UpdateProfessorAsync([FromServices] EscolaDataContext context, [FromRoute] int id, [FromBody] Professor professor);
       

       
        Task<IActionResult> DeleteProfessorAsync([FromServices] EscolaDataContext context, [FromRoute] int id);
    }
}