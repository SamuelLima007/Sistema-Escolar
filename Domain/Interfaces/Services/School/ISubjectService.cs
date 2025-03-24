using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoScores.Data;
using ProjetoScores.Domain.Models;
using ProjetoScores.Domain.ViewModels;

namespace ProjetoScores.Domain.Interfaces
{
    public interface ISubjectService
    {
        Task<Subject> GetSubjectByIdAsync(int id);
        Task<Subject> AddSubjectAsync(EscolaDataContext context, CreateSubjectViewModel subject);
        Task<bool> UpdateSubjectAsync(int id, [FromBody] Subject subject);
        Task<bool> DeleteSubjectAsync(int id);
    }
}