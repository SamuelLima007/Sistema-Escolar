using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoScores.Data;
using ProjetoScores.Domain.Interfaces;
using ProjetoScores.Domain.Models;

namespace ProjetoScores.Repository
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly EscolaDataContext _context;
        public AdministratorRepository(EscolaDataContext context)
        {
            _context = context;
        }
        public async Task<Administrator> GetByIdAsync(int id)
        {
            return await _context.Administratores.FirstOrDefaultAsync(x => x.AdministratorId == id);
        }
        public async Task AddAsync(Administrator administrator)
        {
            await _context.Administratores.AddAsync(administrator);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Administrator administrator)
        {
            _context.Administratores.Update(administrator);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Administrator administrator)
        {
            _context.Administratores.Remove(administrator);
            await _context.SaveChangesAsync();
        }
    }
}