using Backend.Domain.Extensions;
using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;

using ProjetoNotas.ViewModels;
namespace ProjetoNotas.WebUi.Services
{

    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public async Task<ApiResponse<Class>> GetClassByIdAsync(int id)
        {
            try
            {
                var classentity = await _classRepository.GetByIdAsync(id);
                if (classentity == null)
                {
                    return ResponseApiExtension<Class>.CreateApiResponseFail(new ApiResponse<Class>("Classe inexistente"));
                }
                return ResponseApiExtension<Class>.CreateApiResponseSucess(new ApiResponse<Class>("Classe Encontrada", classentity));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<Class>> AddClassAsync(CreateClassViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return ResponseApiExtension<Class>.CreateApiResponseFail(new ApiResponse<Class>("Verifique o formato do JSON", new Class() { }));
                }

                if (await _classRepository.GetByGradeAsync(model.Grade))
                {
                    return ResponseApiExtension<Class>.CreateApiResponseFail(new ApiResponse<Class>("Já existe uma classe com essa grade", new Class() { Grade = model.Grade })); ;
                }
                var classentity = new Class()
                {
                    Grade = model.Grade,
                };
                await _classRepository.AddAsync(classentity);
                return ResponseApiExtension<Class>.CreateApiResponseSucess(new ApiResponse<Class>("Classe adicionada com sucesso", classentity)); ;
            }
            catch
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<Class>> UpdateClassAsync(int id, CreateClassViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return ResponseApiExtension<Class>.CreateApiResponseFail(new ApiResponse<Class>("Verifique o formato do JSON", new Class() { }));
                }

                if (await _classRepository.GetByGradeAsync(model.Grade))
                {
                    return ResponseApiExtension<Class>.CreateApiResponseFail(new ApiResponse<Class>("Já existe uma classe com essa grade", new Class() { Grade = model.Grade })); ;
                }

                var updateclass = await _classRepository.GetByIdAsync(id);
                if (updateclass == null)
                {
                    return ResponseApiExtension<Class>.CreateApiResponseFail(new ApiResponse<Class>("Classe inexistente"));
                }

                updateclass.Grade = model.Grade;
                await _classRepository.UpdateAsync(updateclass);
                return ResponseApiExtension<Class>.CreateApiResponseSucess(new ApiResponse<Class>("Classe Atualizada com sucesso", updateclass)); ;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<Class>> DeleteClassAsync(int id)
        {
            try
            {
                var classentity = await _classRepository.GetByIdAsync(id);
                if (classentity == null)
                {
                    return ResponseApiExtension<Class>.CreateApiResponseFail(new ApiResponse<Class>("Classe inexistente"));
                }

                await _classRepository.DeleteAsync(classentity);
                return ResponseApiExtension<Class>.CreateApiResponseSucess(new ApiResponse<Class>("Classe deletada com sucesso", classentity));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}