using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;

namespace Backend.Domain.Interfaces.Services.School
{
    public interface ISubmittedTaskService
    {
        Task<ApiResponse<SubmittedTask>> GetSubmittedTaskByIdAsync(int studentId, int taskId, int loggedId, string loggedRole);
        Task<ApiResponse<SubmittedTask>> AddSubmittedTaskAsync(CreateSubmittedTaskViewModel model,  string loggedRole, int loggedId);
        Task<ApiResponse<SubmittedTask>> UpdateSubmittedTaskAsync(int studentId, int mytaskId, CreateSubmittedTaskViewModel model, int loggedId, string loggedRole);
        Task<ApiResponse<SubmittedTask>> DeleteSubmittedTaskAsync(int studentId, int mytaskId, int loggedId, string loggedRole);
    }
}