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
    public interface IAdministradorController
    {
        Task<ActionResult<Administrador>> GetAdministradorByIdAsync(int id);
        Task<ActionResult<Administrador>> AddAdministradorAsync([FromServices] EscolaDataContext context,[FromBody] CreateAdministradorViewModel model);
        Task<ActionResult<bool>> UpdateAdministradorAsync(int id, [FromBody] Administrador administrador);
        Task<ActionResult<bool>> DeleteAdministradorAsync(int id);
    }
}