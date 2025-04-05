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
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly EscolaDataContext _context;
        public AdministratorRepository(EscolaDataContext context)
        {
            _context = context;
        }
        public async Task<Administrator> GetByIdAsync(int id)
        {
            return await _context.Administrators.FirstOrDefaultAsync(x => x.AdministratorId == id);
        }
        public async Task AddAsync(Administrator administrator)
        {
            await _context.Administrators.AddAsync(administrator);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Administrator administrator)
        {
            _context.Administrators.Update(administrator);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Administrator administrator)
        {
            _context.Administrators.Remove(administrator);
            await _context.SaveChangesAsync();
        }
    }
}