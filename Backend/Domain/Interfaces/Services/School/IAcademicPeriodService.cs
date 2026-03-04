using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;
using ProjetoNotas.Domain.Models;

namespace Backend.Domain.Interfaces.Services.School
{
    public interface IAcademicPeriodService
    {

        
        Task<ApiResponse<List<AcademicPeriod>>> GetAllAcademicPeriods();
        Task<ApiResponse<AcademicPeriod>> GetAcademicPeriodByIdAsync(int id);
        Task<ApiResponse<AcademicPeriod>> AddAcademicPeriodAsync(CreateAcademicViewModel model);
        Task<ApiResponse<AcademicPeriod>> UpdateAcademicPeriodAsync(int id, CreateAcademicViewModel model);
        Task<ApiResponse<AcademicPeriod>> DeleteAcademicPeriodAsync(int id);
        
    }
}