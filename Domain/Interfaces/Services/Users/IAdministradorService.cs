using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IAdministradorService
    {
        Task<Administrador> GetAdministradorByIdAsync(int id);
        Task<Administrador> AddAdministradorAsync(EscolaDataContext context, CreateAdministradorViewModel administrador);
        Task<bool> UpdateAdministradorAsync(int id, Administrador administrador);
        Task<bool> DeleteAdministradorAsync(int id);
    }
}