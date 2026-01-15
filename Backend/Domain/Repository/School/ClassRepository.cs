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

    public class ClassRepository : IClassRepository
    {
        private readonly EscolaDataContext _context;
        public ClassRepository(EscolaDataContext context)
        {
            _context = context;
        }

        public async Task<List<Class>> GetAll()
        {
            return await _context.Classs.ToListAsync();
        }
        public async Task AddAsync(Class classentity)
        {
            await _context.Classs.AddAsync(classentity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Class classentity)
        {
            _context.Classs.Remove(classentity);
            await _context.SaveChangesAsync();
        }
        public async Task<Class> GetByIdAsync(int id)
        {
            return await _context.Classs.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateAsync(Class classentity)
        {
            _context.Classs.Update(classentity);
            await _context.SaveChangesAsync();
        }
    }
}