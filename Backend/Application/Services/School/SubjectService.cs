using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Extensions;
using Backend.Domain.Models;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;

namespace ProjetoNotas.WebUi.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;

        }
        public async Task<ApiResponse<Subject>> GetSubjectByIdAsync(int id)
        {
            try
            {
                var subject = await _subjectRepository.GetByIdAsync(id);
                if (subject == null)
                {
                    return ResponseApiExtension<Subject>.CreateApiResponseFail(new ApiResponse<Subject>("Disciplina inexistente"));
                }
                 return ResponseApiExtension<Subject>.CreateApiResponseSucess(new ApiResponse<Subject>("Disciplina Encontrada", subject));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }

        }
        public async Task<ApiResponse<Subject>> AddSubjectAsync(CreateSubjectViewModel model)
        {

            try
            {
                if (model == null)
                {
                    return ResponseApiExtension<Subject>.CreateApiResponseFail(new ApiResponse<Subject>("Verifique o formato do JSON", new Subject() { }));
                }

                if (await _subjectRepository.GetByNameAsync(model.Name))
                {
                    return ResponseApiExtension<Subject>.CreateApiResponseFail(new ApiResponse<Subject>("Já existe uma Disciplina com essa grade", new Subject() { Name = model.Name })); ;
                }
                var subject = new Subject()
                {
                    Name = model.Name,
                };
                await _subjectRepository.AddAsync(subject);
                return ResponseApiExtension<Subject>.CreateApiResponseSucess(new ApiResponse<Subject>("Disciplina adicionada com sucesso", subject)); ;
            }
            catch
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<Subject>> UpdateSubjectAsync(int id, CreateSubjectViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return ResponseApiExtension<Subject>.CreateApiResponseFail(new ApiResponse<Subject>("Verifique o formato do JSON", new Subject() { }));
                }

                if (await _subjectRepository.GetByNameAsync(model.Name))
                {
                    return ResponseApiExtension<Subject>.CreateApiResponseFail(new ApiResponse<Subject>("Já existe uma Disciplina com essa grade", new Subject() { Name = model.Name })); ;
                }

                var updatesubject = await _subjectRepository.GetByIdAsync(id);

                if (updatesubject == null)
                {
                    return ResponseApiExtension<Subject>.CreateApiResponseFail(new ApiResponse<Subject>("Disciplina inexistente"));
                }

                updatesubject.Name = model.Name;
                await _subjectRepository.UpdateAsync(updatesubject);
                return ResponseApiExtension<Subject>.CreateApiResponseSucess(new ApiResponse<Subject>("Disciplina Atualizada com sucesso", updatesubject)); ;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<Subject>> DeleteSubjectAsync(int id)
        {
            try
            {
                var subject = await _subjectRepository.GetByIdAsync(id);
                if (subject == null)
                {
                    return ResponseApiExtension<Subject>.CreateApiResponseFail(new ApiResponse<Subject>("Disciplina inexistente"));
                }

                await _subjectRepository.DeleteAsync(subject);
                return ResponseApiExtension<Subject>.CreateApiResponseSucess(new ApiResponse<Subject>("Disciplina deletada", subject));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}