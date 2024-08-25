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
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly EscolaDataContext _context;
        public AdministradorRepository(EscolaDataContext context)
        {
            _context = context;
        }
        public async Task<Administrador> GetByIdAsync(int id)
        {
            return await _context.Administradores.FirstOrDefaultAsync(x => x.AdministradorId == id);
        }
        public async Task AddAsync(Administrador administrador)
        {
            await _context.Administradores.AddAsync(administrador);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Administrador administrador)
        {
            _context.Administradores.Update(administrador);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Administrador administrador)
        {
            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();
        }
    }
}