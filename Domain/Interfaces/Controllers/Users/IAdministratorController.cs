using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoScores.Data;
using ProjetoScores.Domain.Models;
using ProjetoScores.Domain.ViewModels;
using ProjetoScores.ViewModels;

namespace ProjetoScores.Domain.Interfaces
{
    public interface IAdministratorController
    {
        Task<ActionResult<Administrator>> GetAdministratorByIdAsync(int id);
        Task<ActionResult<Administrator>> AddAdministratorAsync([FromServices] EscolaDataContext context,[FromBody] CreateAdministratorViewModel model);
        Task<ActionResult<bool>> UpdateAdministratorAsync(int id, [FromBody] Administrator administrator);
        Task<ActionResult<bool>> DeleteAdministratorAsync(int id);
    }
}