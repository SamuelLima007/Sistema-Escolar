using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Data;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IAlunoService
    {
        Task<Aluno> GetAlunoByIdAsync(int id);
        Task<Aluno> AddAlunoAsync(CreateAlunoViewModel aluno);
        Task<bool> UpdateAlunoAsync(int id, Aluno aluno);
        Task<bool> DeleteAlunoAsync(int id);
    }
}