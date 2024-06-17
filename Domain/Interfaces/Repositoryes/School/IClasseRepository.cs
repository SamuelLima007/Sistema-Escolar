using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Models;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IClasseRepository
    {
        Task<Classe> GetByIdAsync(int id);
        Task AddAsync(Classe classe);
        Task UpdateAsync(Classe classe);
        Task DeleteAsync(Classe classe);
    }
}