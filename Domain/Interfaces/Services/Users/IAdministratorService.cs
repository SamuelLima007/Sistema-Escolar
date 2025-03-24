using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoScores.Data;
using ProjetoScores.Domain.Models;
using ProjetoScores.Domain.ViewModels;
using ProjetoScores.Models;
using ProjetoScores.ViewModels;

namespace ProjetoScores.Domain.Interfaces
{
    public interface IAdministratorService
    {
        Task<Administrator> GetAdministratorByIdAsync(int id);
        Task<Administrator> AddAdministratorAsync(EscolaDataContext context, CreateAdministratorViewModel administrator);
        Task<bool> UpdateAdministratorAsync(int id, Administrator administrator);
        Task<bool> DeleteAdministratorAsync(int id);
    }
}