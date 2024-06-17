using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IAdministradorRepository
    {
        Task<Administrador> GetByIdAsync(int id);
        Task AddAsync(Administrador administrador);
        Task UpdateAsync(Administrador administrador);
        Task DeleteAsync(Administrador administrador);
    }
}