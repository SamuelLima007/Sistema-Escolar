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
    public interface IStudentService
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> AddStudentAsync(CreateStudentViewModel student);
        Task<bool> UpdateStudentAsync(int id, CreateStudentViewModel student);
        Task<bool> DeleteStudentAsync(int id);
    }
}