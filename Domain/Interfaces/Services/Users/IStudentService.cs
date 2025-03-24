using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoScores.Data;
using ProjetoScores.Models;
using ProjetoScores.ViewModels;

namespace ProjetoScores.Domain.Interfaces
{
    public interface IStudentService
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> AddStudentAsync(CreateStudentViewModel student);
        Task<bool> UpdateStudentAsync(int id, Student student);
        Task<bool> DeleteStudentAsync(int id);
    }
}