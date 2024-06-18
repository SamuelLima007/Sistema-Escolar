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
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly EscolaDataContext _context;
        public DisciplinaRepository(EscolaDataContext context)
        {
            _context = context;
        }
        public async Task<Disciplina> GetByIdAsync(int id)
        {
            return await _context.Disciplinas.FirstOrDefaultAsync(x => x.DisciplinaId == id);

        }
        public async Task AddAsync(Disciplina disciplina)
        {
            await _context.Disciplinas.AddAsync(disciplina);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Disciplina disciplina)
        {
            _context.Disciplinas.Update(disciplina);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Disciplina disciplina)
        {
            _context.Disciplinas.Remove(disciplina);
            await _context.SaveChangesAsync();
        }
    }
}