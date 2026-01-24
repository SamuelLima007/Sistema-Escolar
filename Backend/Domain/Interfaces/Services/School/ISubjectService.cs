using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface ISubjectService
    {
        Task<ApiResponse<Subject>> GetSubjectByIdAsync(int id);
        Task<ApiResponse<Subject>> AddSubjectAsync(CreateSubjectViewModel subject);
        Task<ApiResponse<Subject>> UpdateSubjectAsync(int id, CreateSubjectViewModel subject);
        Task<ApiResponse<Subject>> DeleteSubjectAsync(int id);
    }
}