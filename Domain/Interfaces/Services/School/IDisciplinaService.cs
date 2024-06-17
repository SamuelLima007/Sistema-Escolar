using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IDisciplinaService
    {
        Task<Disciplina> GetDisciplinaByIdAsync(int id);
        Task<Disciplina> AddDisciplinaAsync(EscolaDataContext context, CreateDisciplinaViewModel disciplina);
        Task<bool> UpdateDisciplinaAsync(int id, [FromBody] Disciplina disciplina);
        Task<bool> DeleteDisciplinaAsync(int id);
    }
}