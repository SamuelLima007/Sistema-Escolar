using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IClassRepository
    {

        Task<List<Class>> GetAll();
        Task<Class> GetByIdAsync(int id);
        Task AddAsync(Class classentity);
        Task UpdateAsync(Class classentity);
        Task DeleteAsync(Class classentity);
        Task<bool> GetByGradeAsync(string grade);

        
    }
}