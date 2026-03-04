using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Interfaces.Repositoryes.School;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Models;

namespace Backend.Domain.Repository.School
{
    public class AcademicPeriodRepository : IAcademicPeriodRepository
    {
    private readonly EscolaDataContext _context;
        public AcademicPeriodRepository(EscolaDataContext context)
        {
            _context = context;
        }

        public async Task<List<AcademicPeriod>> GetAll()
        {
            return await _context.Periods.ToListAsync();
        }
        public async Task AddAsync(AcademicPeriod model)
        {
            await _context.Periods.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(AcademicPeriod model)
        {
            _context.Periods.Remove(model);
            await _context.SaveChangesAsync();
        }
        public async Task<AcademicPeriod> GetByIdAsync(int id)
        {
            return await _context.Periods.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(AcademicPeriod model)
        {
            _context.Periods.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}