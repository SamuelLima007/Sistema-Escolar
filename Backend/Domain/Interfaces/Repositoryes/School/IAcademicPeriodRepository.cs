using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace Backend.Domain.Interfaces.Repositoryes.School
{
    public interface IAcademicPeriodRepository
    {
        Task<List<AcademicPeriod>> GetAll();
        Task<AcademicPeriod> GetByIdAsync(int studentId);
        Task AddAsync(AcademicPeriod mytask);
        Task UpdateAsync(AcademicPeriod mytask);
        Task DeleteAsync(AcademicPeriod mytask);
    }
}