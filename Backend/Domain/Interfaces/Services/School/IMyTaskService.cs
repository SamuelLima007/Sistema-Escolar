using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.Data;
using Backend.Domain.Models;

namespace ProjetoNotas.Domain.Interfaces.Services.School
{
    public interface IMyTaskService
    {
        Task<ApiResponse<MyTask>> GetMyTaskByIdAsync(int id, string loggedRole, int loggedId);
        Task<ApiResponse<MyTask>> AddMyTaskAsync(CreateMyTaskViewModel user, int loggedId);
        Task<ApiResponse<MyTask>> UpdateMyTaskAsync(int id, CreateMyTaskViewModel myclass, string loggedRole, int loggedId);
        Task <ApiResponse<MyTask>> DeleteMyTaskAsync(int id, string loggedRole, int loggedId);
    }
}