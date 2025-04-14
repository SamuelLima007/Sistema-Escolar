using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Models;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IClassRepository
    {

        Task<List<Class>> GetAll();
        Task<Class> GetByIdAsync(int id);
        Task AddAsync(Class classentity);
        Task UpdateAsync(Class classentity);
        Task DeleteAsync(Class classentity);
    }
}