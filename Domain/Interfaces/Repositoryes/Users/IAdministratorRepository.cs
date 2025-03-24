using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoScores.Domain.Models;

namespace ProjetoScores.Domain.Interfaces
{
    public interface IAdministratorRepository
    {
        Task<Administrator> GetByIdAsync(int id);
        Task AddAsync(Administrator administrator);
        Task UpdateAsync(Administrator administrator);
        Task DeleteAsync(Administrator administrator);
    }
}