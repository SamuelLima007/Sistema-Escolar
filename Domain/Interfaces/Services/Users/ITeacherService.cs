using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoScores.Data;
using ProjetoScores.Models;
using ProjetoScores.ViewModels;

namespace ProjetoScores.Domain.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task<Teacher> AddTeacherAsync(EscolaDataContext context, CreateTeacherViewModel student);
        Task<bool> UpdateTeacherAsync(int id, CreateTeacherViewModel teacher);
        Task<bool> DeleteTeacherAsync(int id);
    }
}