using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Domain.Interfaces.Repositoryes.School;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Data;

namespace ProjetoNotas.Domain.Repository
{
    public class MyTaskRepository : IMyTaskRepository
    {
        private readonly EscolaDataContext _context;
        public MyTaskRepository(EscolaDataContext context)
        {
            _context = context;
        }

        public async Task<List<MyTask>> GetAll()
        {
            return await _context.MyTasks.ToListAsync();
        }
        public async Task AddAsync(MyTask myTask)
        {
            await _context.MyTasks.AddAsync(myTask);
            await _context.SaveChangesAsync();
        }
       
        public async Task DeleteAsync(MyTask myTask)
        {
            _context.MyTasks.Remove(myTask);
            await _context.SaveChangesAsync();
        }
        public async Task<MyTask> GetByIdAsync(int id)
        {
            return await _context.MyTasks.FirstOrDefaultAsync(x => x.MyTaskId == id);
        }
        public async Task UpdateAsync(MyTask myTask)
        {
            _context.MyTasks.Update(myTask);
            await _context.SaveChangesAsync();
        }
    }
}