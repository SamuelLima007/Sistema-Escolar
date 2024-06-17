using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Models;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IProfessorRepository
    {
         Task<Professor> GetByIdAsync(int id);
        Task AddAsync(Professor professor);
        Task UpdateAsync(Professor professor);
        Task DeleteAsync(Professor professor);
    }
}