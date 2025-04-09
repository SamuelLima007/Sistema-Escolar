using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Models;

namespace ProjetoNotas.Repository
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
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);
        }
        public async Task UpdateAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }
    }
}