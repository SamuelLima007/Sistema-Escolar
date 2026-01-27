using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;

namespace Backend.Domain.Interfaces.Services.School
{
    public interface ITaskSubmissionService
    {
        Task<ApiResponse<TaskSubmission>> GetTaskSubmittedByIdAsync(int studentId, int taskId, int loggedId, string loggedRole);
        Task<ApiResponse<TaskSubmission>> AddTaskSubmittedAsync(CreateSubmittedTaskViewModel model);
        Task<ApiResponse<TaskSubmission>> UpdateTaskSubmittedAsync(int studentId, int mytaskId, CreateSubmittedTaskViewModel model, int loggedId, string loggedRole);
        Task<ApiResponse<TaskSubmission>> DeleteTaskSubmittedAsync(int studentId, int mytaskId, int loggedId, string loggedRole);
    }
}