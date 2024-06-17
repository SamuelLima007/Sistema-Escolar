using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Models;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IAlunoRepository
    {
        Task<Aluno> GetByIdAsync(int id);
        Task AddAsync(Aluno aluno);
        Task UpdateAsync(Aluno aluno);
        Task DeleteAsync(Aluno aluno);
    }
}