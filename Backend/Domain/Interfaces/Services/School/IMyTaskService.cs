using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.Data;

namespace ProjetoNotas.Domain.Interfaces.Services.School
{
    public interface IMyTaskService
    {
        Task<MyTask> GetMyTaskByIdAsync(int id);
        Task<MyTask> AddMyTaskAsync(CreateMyTaskViewModel user);
        Task<bool> UpdateMyTaskAsync(int id, CreateMyTaskViewModel myclass);
        Task<bool> DeleteMyTaskAsync(int id);
    }
}