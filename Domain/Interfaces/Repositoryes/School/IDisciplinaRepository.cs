using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IDisciplinaRepository
    {
        Task<Disciplina> GetByIdAsync(int id);
        Task AddAsync(Disciplina disciplina);
        Task UpdateAsync(Disciplina disciplina);
        Task DeleteAsync(Disciplina disciplina);
    }
}