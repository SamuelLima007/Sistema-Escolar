using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces.Repositoryes.School;
using Backend.Domain.Interfaces.Services.School;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;
using ProjetoNotas.Domain.Models;

namespace Backend.Application.Services.School
{
    public class AcademicPeriodService : IAcademicPeriodService
    {
        private readonly IAcademicPeriodRepository _academicperiod;
        public AcademicPeriodService(IAcademicPeriodRepository academicperiod)
        {
            _academicperiod = academicperiod;

        }

        public async Task<ApiResponse<List<AcademicPeriod>>> GetAllAcademicPeriods()
        {

            try
            {
                var academicperiods = await _academicperiod.GetAll();
                if (academicperiods == null)
                {
                    return ResponseApiExtension<List<AcademicPeriod>>.CreateApiResponseFail(new ApiResponse<List<AcademicPeriod>>("Unidade inexistente"));
                }
                return ResponseApiExtension<List<AcademicPeriod>>.CreateApiResponseSucess(new ApiResponse<List<AcademicPeriod>>(" Unidade Encontrada", academicperiods));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }


        public async Task<ApiResponse<AcademicPeriod>> GetAcademicPeriodByIdAsync(int id)
        {
            try
            {
                var academicperiod = await _academicperiod.GetByIdAsync(id);
                if (academicperiod == null)
                {
                    return ResponseApiExtension<AcademicPeriod>.CreateApiResponseFail(new ApiResponse<AcademicPeriod>(" Unidade inexistente"));
                }
                return ResponseApiExtension<AcademicPeriod>.CreateApiResponseSucess(new ApiResponse<AcademicPeriod>(" Unidade Encontrada", academicperiod));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }

        }
        public async Task<ApiResponse<AcademicPeriod>> AddAcademicPeriodAsync(CreateAcademicViewModel model)
        {

            try
            {
                if (model == null)
                {
                    return ResponseApiExtension<AcademicPeriod>.CreateApiResponseFail(new ApiResponse<AcademicPeriod>("Verifique o formato do JSON", new AcademicPeriod() { }));
                }

                var academicperiod = new AcademicPeriod()
                {
                    Year = model.Year,
                    Unit = model.Unit,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,

                };
                await _academicperiod.AddAsync(academicperiod);
                return ResponseApiExtension<AcademicPeriod>.CreateApiResponseSucess(new ApiResponse<AcademicPeriod>(" Unidade adicionada com sucesso", academicperiod)); ;
            }
            catch
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<AcademicPeriod>> UpdateAcademicPeriodAsync(int id, CreateAcademicViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return ResponseApiExtension<AcademicPeriod>.CreateApiResponseFail(new ApiResponse<AcademicPeriod>("Verifique o formato do JSON", new AcademicPeriod() { }));
                }


                var updateacademicperiod = await _academicperiod.GetByIdAsync(id);

                if (updateacademicperiod == null)
                {
                    return ResponseApiExtension<AcademicPeriod>.CreateApiResponseFail(new ApiResponse<AcademicPeriod>(" Unidade inexistente"));
                }

                updateacademicperiod.Update(model);
                await _academicperiod.UpdateAsync(updateacademicperiod);
                return ResponseApiExtension<AcademicPeriod>.CreateApiResponseSucess(new ApiResponse<AcademicPeriod>(" Unidade Atualizada com sucesso", updateacademicperiod)); ;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<AcademicPeriod>> DeleteAcademicPeriodAsync(int id)
        {
            try
            {
                var academicperiod = await _academicperiod.GetByIdAsync(id);
                if (academicperiod == null)
                {
                    return ResponseApiExtension<AcademicPeriod>.CreateApiResponseFail(new ApiResponse<AcademicPeriod>(" Unidade inexistente"));
                }

                await _academicperiod.DeleteAsync(academicperiod);
                return ResponseApiExtension<AcademicPeriod>.CreateApiResponseSucess(new ApiResponse<AcademicPeriod>(" Unidade deletada", academicperiod));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }


}