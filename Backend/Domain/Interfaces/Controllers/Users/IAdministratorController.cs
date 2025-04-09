using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IAdministratorController
    {
        Task<ActionResult<Administrator>> GetAdministratorByIdAsync(int id);
        Task<ActionResult<Administrator>> AddAdministratorAsync([FromBody] CreateAdministratorViewModel model);
        Task<ActionResult<bool>> UpdateAdministratorAsync(int id, [FromBody] CreateAdministratorViewModel administrator);
        Task<ActionResult<bool>> DeleteAdministratorAsync(int id);
    }
}