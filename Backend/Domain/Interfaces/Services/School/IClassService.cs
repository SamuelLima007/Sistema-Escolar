using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Models;

using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IClassService
    {
        Task<ApiResponse<Class>> GetClassByIdAsync(int id);
        Task<ApiResponse<Class>> AddClassAsync(CreateClassViewModel user);
        Task<ApiResponse<Class>> UpdateClassAsync(int id, CreateClassViewModel classentity);
        Task<ApiResponse<Class>> DeleteClassAsync(int id);
    }
}