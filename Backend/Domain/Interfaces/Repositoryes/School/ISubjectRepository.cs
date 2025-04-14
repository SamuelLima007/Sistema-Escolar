using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface ISubjectRepository
    {

        Task<List<Subject>> GetAll();
        Task<Subject> GetByIdAsync(int id);
        Task AddAsync(Subject subject);
        Task UpdateAsync(Subject subject);
        Task DeleteAsync(Subject subject);
    }
}