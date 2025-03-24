using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoScores.Data;
using ProjetoScores.Domain.Interfaces;
using ProjetoScores.Models;

namespace ProjetoScores.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly EscolaDataContext _context;
        public TeacherRepository(EscolaDataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Teacher teacher)
        {
            await _context.Teacheres.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Teacher teacher)
        {
            _context.Teacheres.Remove(teacher);
            await _context.SaveChangesAsync();
        }
        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _context.Teacheres.FirstOrDefaultAsync(x => x.TeacherId == id);
        }
        public async Task UpdateAsync(Teacher teacher)
        {
            _context.Teacheres.Update(teacher);
            await _context.SaveChangesAsync();
        }
    }
}