using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;

namespace Backend.Domain.Interfaces.Repositoryes.School
{
    public interface ITaskSubmissionRepository
    {
        Task<List<TaskSubmission>> GetAll();
        Task<TaskSubmission> GetByIdAsync(int studentId, int taskId);
        Task AddAsync(TaskSubmission mytask);
        Task UpdateAsync(TaskSubmission mytask);
        Task DeleteAsync(TaskSubmission mytask);
    }
}