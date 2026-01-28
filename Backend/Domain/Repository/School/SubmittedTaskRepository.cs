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
    public class SubmittedTaskRepository : ISubmittedTaskRepository
    {
        private readonly EscolaDataContext _context;
        public SubmittedTaskRepository(EscolaDataContext context)
        {
            _context = context;
        }

        public async Task<List<SubmittedTask>> GetAll()
        {
            return await _context.SubmittedTasks.ToListAsync();
        }
        public async Task AddAsync(SubmittedTask myTask)
        {
            await _context.SubmittedTasks.AddAsync(myTask);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SubmittedTask myTask)
        {
            _context.SubmittedTasks.Remove(myTask);
            await _context.SaveChangesAsync();
        }
        public async Task<SubmittedTask> GetByIdAsync(int studentId, int taskId)
        {
            return await _context.SubmittedTasks.FirstOrDefaultAsync(x => x.MyTaskId == taskId && x.StudentId == studentId);
        }
        public async Task UpdateAsync(SubmittedTask myTask)
        {
            _context.SubmittedTasks.Update(myTask);
            await _context.SaveChangesAsync();
        }

    }
}