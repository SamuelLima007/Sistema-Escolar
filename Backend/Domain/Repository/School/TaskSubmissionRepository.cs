using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Interfaces.Repositoryes.School;
using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Data;

namespace Backend.Domain.Repository.School
{
    public class TaskSubmissionRepository : ITaskSubmissionRepository
    {
        private readonly EscolaDataContext _context;
        public TaskSubmissionRepository(EscolaDataContext context)
        {
            _context = context;
        }

        public async Task<List<TaskSubmission>> GetAll()
        {
            return await _context.TasksSubmission.ToListAsync();
        }
        public async Task AddAsync(TaskSubmission myTask)
        {
            await _context.TasksSubmission.AddAsync(myTask);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TaskSubmission myTask)
        {
            _context.TasksSubmission.Remove(myTask);
            await _context.SaveChangesAsync();
        }
        public async Task<TaskSubmission> GetByIdAsync(int studentId, int taskId)
        {
            return await _context.TasksSubmission.FirstOrDefaultAsync(x => x.MyTaskId == taskId && x.StudentId == studentId);
        }
        public async Task UpdateAsync(TaskSubmission myTask)
        {
            _context.TasksSubmission.Update(myTask);
            await _context.SaveChangesAsync();
        }

    }
}