using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Data;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task<Teacher> AddTeacherAsync(CreateTeacherViewModel teacher, int id);
        Task<bool> UpdateTeacherAsync(int id, CreateTeacherViewModel teacher);
        Task<bool> DeleteTeacherAsync(int id);
    }
}