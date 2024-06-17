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
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly EscolaDataContext _context;

        public ProfessorRepository(EscolaDataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Professor professor)
        {
            await _context.Professores.AddAsync(professor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Professor professor)
        {
            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();
        }

        public async Task<Professor> GetByIdAsync(int id)
        {
            return await _context.Professores.FirstOrDefaultAsync(x => x.ProfessorId == id);
        }

        public async Task UpdateAsync(Professor professor)
        {
            _context.Professores.Update(professor);
            await _context.SaveChangesAsync();
        }
    }
}