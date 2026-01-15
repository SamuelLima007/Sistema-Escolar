using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Domain.ViewModels;

namespace Backend.Domain.Interfaces.Controllers.School
{
    public interface ITaskSubmissionController
    {
        Task<ActionResult<TaskSubmission>> GetTaskSubmissionByIdAsync(int studentId, int taskId);
        Task<ActionResult<TaskSubmission>> AddTaskSubmissionAsync(CreateSubmittedTaskViewModel model);
        Task<ActionResult<bool>> UpdateTaskSubmissionAsync(int studentId, int taskId, CreateSubmittedTaskViewModel model);
        Task<ActionResult<bool>> DeleteTaskSubmissionAsync(int studentId,int mytaskId);
    }
}