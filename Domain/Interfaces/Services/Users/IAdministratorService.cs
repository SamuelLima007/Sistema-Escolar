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
    public interface IAdministratorService
    {
        Task<Administrator> GetAdministratorByIdAsync(int id);
        Task<Administrator> AddAdministratorAsync(CreateAdministratorViewModel administrator);
        Task<bool> UpdateAdministratorAsync(int id, CreateAdministratorViewModel administrator);
        Task<bool> DeleteAdministratorAsync(int id);
    }
}