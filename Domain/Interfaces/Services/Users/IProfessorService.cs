using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Data;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IProfessorService
    {
        Task<Professor> GetProfessorByIdAsync(int id);
        Task<Professor> AddProfessorAsync(EscolaDataContext context, CreateProfessorViewModel aluno);
        Task<bool> UpdateProfessorAsync(int id, CreateProfessorViewModel professor);
        Task<bool> DeleteProfessorAsync(int id);
    }
}