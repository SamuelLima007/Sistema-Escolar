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
    
    public class ClasseRepository : IClasseRepository
    {
         private readonly EscolaDataContext _context;

        public ClasseRepository(EscolaDataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Classe classe)
        {
             await _context.Classes.AddAsync(classe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Classe classe)
        {
             _context.Classes.Remove(classe);
            await _context.SaveChangesAsync();
        }

        public async Task<Classe> GetByIdAsync(int id)
        {
            return await _context.Classes.FirstOrDefaultAsync(x => x.ClasseId == id);
        }

        public async Task UpdateAsync(Classe classe)
        {
            _context.Classes.Update(classe);
            await _context.SaveChangesAsync();
        }
    }
}