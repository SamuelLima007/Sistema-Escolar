using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;

namespace Backend.Domain.Interfaces.Repositoryes.School
{
    public interface ISubmittedTaskRepository
    {
        Task<List<SubmittedTask>> GetAll();
        Task<SubmittedTask> GetByIdAsync(int studentId, int taskId);
        Task AddAsync(SubmittedTask mytask);
        Task UpdateAsync(SubmittedTask mytask);
        Task DeleteAsync(SubmittedTask mytask);
    }
}