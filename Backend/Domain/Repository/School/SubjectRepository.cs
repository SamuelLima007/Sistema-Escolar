using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly EscolaDataContext _context;
        public SubjectRepository(EscolaDataContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetAll()
        {
            return await _context.Subjects.ToListAsync();
        }
        public async Task<Subject> GetByIdAsync(int id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(x => x.SubjectId == id);

        }
        public async Task AddAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Subject subject)
        {
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }
    }
}