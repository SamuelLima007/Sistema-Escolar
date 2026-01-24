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
        Task<TaskSubmission> GetTaskSubmittedByIdAsync(int studentId, int taskId);
        Task<TaskSubmission> AddTaskSubmittedAsync(CreateSubmittedTaskViewModel model);
        Task<bool> UpdateTaskSubmittedAsync(int studentId, int mytaskId, CreateSubmittedTaskViewModel model);
        Task<ApiResponse<TaskSubmission>> DeleteTaskSubmittedAsync(int studentId, int mytaskId);
    }
}