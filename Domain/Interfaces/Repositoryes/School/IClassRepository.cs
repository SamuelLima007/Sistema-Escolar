using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoScores.Models;

namespace ProjetoScores.Domain.Interfaces
{
    public interface IClassRepository
    {
        Task<Class> GetByIdAsync(int id);
        Task AddAsync(Class classentity);
        Task UpdateAsync(Class classentity);
        Task DeleteAsync(Class classentity);
    }
}