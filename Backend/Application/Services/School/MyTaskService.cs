using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Interfaces.Repositoryes.School;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces.Services.School;
using Microsoft.VisualBasic;
using Backend.Domain.Models;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces.Repositoryes.Users;

namespace ProjetoNotas.Application.Services
{
    public class MyTaskService : IMyTaskService
    {
        private readonly IMyTaskRepository _mytaskRepository;
        private readonly ITeacherAssignmentRepository _teacherassignmentRepository;
        public MyTaskService(IMyTaskRepository mytaskRepository, ITeacherAssignmentRepository teacherAssignmentRepository)
        {
            _mytaskRepository = mytaskRepository;
            _teacherassignmentRepository = teacherAssignmentRepository;

        }
        public async Task<ApiResponse<MyTask>> GetMyTaskByIdAsync(int id, string loggedRole, int loggedId)
        {
            try
            {
                var mytask = await _mytaskRepository.GetByIdAsync(id);
                if (mytask == null)
                {
                    return ResponseApiExtension<MyTask>.CreateApiResponseFail(new ApiResponse<MyTask>("Tarefa inexistente"));
                }
                if (loggedRole == "Teacher" && loggedId != mytask.TeacherId)
                {
                    return ResponseApiExtension<MyTask>.CreateApiResponseFail(new ApiResponse<MyTask>("Permitido apenas para o professor que criou a tarefa", "Forbidden"));
                }

                return ResponseApiExtension<MyTask>.CreateApiResponseSucess(new ApiResponse<MyTask>("Tarefa Encontrada", mytask));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }


        }
        public async Task<ApiResponse<MyTask>> AddMyTaskAsync(CreateMyTaskViewModel model, int loggedId)
        {

            if (model == null)
            {
                return ResponseApiExtension<MyTask>.CreateApiResponseFail(new ApiResponse<MyTask>("Verifique o formato do JSON", new MyTask() { }));
            }

            if (!await _teacherassignmentRepository.FindAssignment(loggedId, model.Classid, model.SubjectId))
            {
                return ResponseApiExtension<MyTask>.CreateApiResponseFail(new ApiResponse<MyTask>("O professor pode adicionar apenas tarefas da classe e disciplina que ele leciona", "Forbidden"));
            }

            var mytask = new MyTask()
            {
                Name = string.IsNullOrWhiteSpace(model.Name) ? model.Name : model.Name,
                Description = string.IsNullOrWhiteSpace(model.Description) ? model.Description : model.Description,
                CreationDate = model.CreationDate,
                ExpirationDate = model.ExpirationDate,
                ClassId = model.Classid,
                SubjectId = model.SubjectId,
                TeacherId = loggedId,
                score = model.Score
            };

            await _mytaskRepository.AddAsync(mytask);
            return ResponseApiExtension<MyTask>.CreateApiResponseSucess(new ApiResponse<MyTask>("Tarefa adicionada com sucesso", mytask)); ;

        }
        public async Task<ApiResponse<MyTask>> UpdateMyTaskAsync(int id, CreateMyTaskViewModel model, string loggedRole, int loggedId)
        {
            try
            {
                if (model == null)
                {
                    return ResponseApiExtension<MyTask>.CreateApiResponseFail(new ApiResponse<MyTask>("Verifique o formato do JSON", new MyTask() { }));
                }

                var mytask = await _mytaskRepository.GetByIdAsync(id);
                if (mytask == null)
                {
                    return ResponseApiExtension<MyTask>.CreateApiResponseFail(new ApiResponse<MyTask>("Tarefa inexistente"));
                }

                if (loggedRole == "Teacher" && loggedId != mytask.TeacherId)
                {
                    return ResponseApiExtension<MyTask>.CreateApiResponseFail(new ApiResponse<MyTask>("Apenas o professor que criou a tarefa pode atualizar", "Forbidden"));
                }

                mytask.Name = string.IsNullOrWhiteSpace(model.Name) ? model.Name : model.Name;
                mytask.Description = string.IsNullOrWhiteSpace(model.Description) ? model.Description : model.Description;
                mytask.ExpirationDate = model.ExpirationDate;

                await _mytaskRepository.UpdateAsync(mytask);
                return ResponseApiExtension<MyTask>.CreateApiResponseSucess(new ApiResponse<MyTask>("Tarefa Atualizada com sucesso", mytask)); ;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }


        }
        public async Task<ApiResponse<MyTask>> DeleteMyTaskAsync(int id, string loggedRole, int loggedId)
        {
            try
            {
                var mytask = await _mytaskRepository.GetByIdAsync(id);
                if (mytask == null)
                {
                    return ResponseApiExtension<MyTask>.CreateApiResponseFail(new ApiResponse<MyTask>("Tarefa inexistente"));
                }
                if (loggedRole == "Teacher" && loggedId != mytask.TeacherId)
                {
                    return ResponseApiExtension<MyTask>.CreateApiResponseFail(new ApiResponse<MyTask>("Apenas o professor que criou a tarefa pode fazer a exclusão", "Forbidden"));
                }
                await _mytaskRepository.DeleteAsync(mytask);
                return ResponseApiExtension<MyTask>.CreateApiResponseSucess(new ApiResponse<MyTask>("Tarefa deletada", mytask));

            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}