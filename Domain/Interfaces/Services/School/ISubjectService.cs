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
    public interface ISubjectService
    {
        Task<Subject> GetSubjectByIdAsync(int id);
        Task<Subject> AddSubjectAsync(CreateSubjectViewModel subject);
        Task<bool> UpdateSubjectAsync(int id, CreateSubjectViewModel subject);
        Task<bool> DeleteSubjectAsync(int id);
    }
}