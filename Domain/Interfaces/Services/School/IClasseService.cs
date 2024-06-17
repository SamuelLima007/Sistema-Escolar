using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Data;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IClasseService
    {
        Task<Classe> GetClasseByIdAsync(int id);
        Task<Classe> AddClasseAsync(EscolaDataContext context, CreateClasseViewModel aluno);
        Task<bool> UpdateClasseAsync(int id, Classe classe);
        Task<bool> DeleteClasseAsync(int id);
    }
}