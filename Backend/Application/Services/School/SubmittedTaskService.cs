using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces.Repositoryes.School;
using Backend.Domain.Interfaces.Services.School;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Interfaces.Repositoryes.School;
using ProjetoNotas.Domain.Models;

namespace Backend.Application.Services.School
{
    public class SubmittedTaskService : ISubmittedTaskService
    {
        private readonly ISubmittedTaskRepository _submittedtaskRepository;
        private readonly IMyTaskRepository _mytaskRepository;
        private readonly IUserRepository _userRepository;
        public SubmittedTaskService(ISubmittedTaskRepository submittedtaskRepositoryRepository, IMyTaskRepository mytaskRepository, IUserRepository userRepository)
        {
            _submittedtaskRepository = submittedtaskRepositoryRepository;
            _mytaskRepository = mytaskRepository;
            _userRepository = userRepository;
        }
        public async Task<ApiResponse<SubmittedTask>> GetSubmittedTaskByIdAsync(int studentId, int mytaskId, int loggedId, string loggedRole)
        {
            try
            {
                var mytask = await _mytaskRepository.GetByIdAsync(mytaskId);
                var submittedTask = await _submittedtaskRepository.GetByIdAsync(studentId, mytaskId);

                if (submittedTask == null)
                {
                    return ResponseApiExtension<SubmittedTask>.CreateApiResponseFail(new ApiResponse<SubmittedTask>("Tarefa inexistente"));
                }

                if (loggedRole == "Teacher" && loggedId != mytask.TeacherId)
                {
                    return ResponseApiExtension<SubmittedTask>.CreateApiResponseFail(new ApiResponse<SubmittedTask>("Permitido apenas para o professor que criou a tarefa", "Forbidden"));
                }

                return ResponseApiExtension<SubmittedTask>.CreateApiResponseSucess(new ApiResponse<SubmittedTask>("Tarefa Encontrada", submittedTask));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<SubmittedTask>> AddSubmittedTaskAsync(CreateSubmittedTaskViewModel model, string loggedRole, int loggedId)
        {

            if (model == null)
            {
                return ResponseApiExtension<SubmittedTask>.CreateApiResponseFail(new ApiResponse<SubmittedTask>("Verifique o formato do JSON", new SubmittedTask() { }));
            }
            var mytask = await _mytaskRepository.GetByIdAsync(model.MyTaskId);
            var student = await _userRepository.GetByIdAsync(model.StudentId);

            if (loggedRole == "Teacher" && loggedId != mytask.TeacherId)
            {
                return ResponseApiExtension<SubmittedTask>.CreateApiResponseFail(new ApiResponse<SubmittedTask>("Apenas o professor que criou a tarefa pode adicionar a nota", "Forbidden"));
            }

            else if (student.ClassId != mytask.ClassId)
            {
                return ResponseApiExtension<SubmittedTask>.CreateApiResponseFail(new ApiResponse<SubmittedTask>("O estudante precisa estar na mesma classe que a tarefa"));
            }

            var submittedTask = new SubmittedTask()
            {
                StudentId = model.StudentId,
                MyTaskId = model.MyTaskId,
                Score = model.Score
            };

            await _submittedtaskRepository.AddAsync(submittedTask);
            return ResponseApiExtension<SubmittedTask>.CreateApiResponseSucess(new ApiResponse<SubmittedTask>("Nota da tarefa adicionada com sucesso", submittedTask));
        }
        public async Task<ApiResponse<SubmittedTask>> UpdateSubmittedTaskAsync(int studentId, int mytaskId, CreateSubmittedTaskViewModel model, int loggedId, string loggedRole)
        {
            try
            {
                var submittedTask = await _submittedtaskRepository.GetByIdAsync(studentId, mytaskId);
                var mytask = await _mytaskRepository.GetByIdAsync(mytaskId);
                if (model == null)
                {
                    return ResponseApiExtension<SubmittedTask>.CreateApiResponseFail(new ApiResponse<SubmittedTask>("Verifique o formato do JSON", new SubmittedTask() { }));
                }

                if (submittedTask == null)
                {
                    return ResponseApiExtension<SubmittedTask>.CreateApiResponseFail(new ApiResponse<SubmittedTask>("Tarefa não encontrada"));
                }

                else if (loggedRole == "Teacher" && loggedId != mytask.TeacherId)
                {
                    return ResponseApiExtension<SubmittedTask>.CreateApiResponseFail(new ApiResponse<SubmittedTask>("Apenas o professor que criou a tarefa pode atualizar a nota", "Forbidden"));
                }

                submittedTask.Score = model.Score;
                _submittedtaskRepository.UpdateAsync(submittedTask);

                return ResponseApiExtension<SubmittedTask>.CreateApiResponseSucess(new ApiResponse<SubmittedTask>("Nota atualizada com sucesso", submittedTask)); ;

            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<SubmittedTask>> DeleteSubmittedTaskAsync(int studentId, int mytaskId, int loggedId, string loggedRole)
        {
            try
            {
                var submittedTask = await _submittedtaskRepository.GetByIdAsync(studentId, mytaskId);
                var mytask = await _mytaskRepository.GetByIdAsync(mytaskId);
                if (submittedTask == null)
                {
                    return ResponseApiExtension<SubmittedTask>.CreateApiResponseFail(new ApiResponse<SubmittedTask>("Tarefa inexistente"));
                }
                else if (loggedRole == "Teacher" && loggedId != mytask.TeacherId)
                {
                    return ResponseApiExtension<SubmittedTask>.CreateApiResponseFail(new ApiResponse<SubmittedTask>("Apenas o professor que criou a tarefa pode fazer a exclusão", "Forbidden"));
                }

                await _submittedtaskRepository.DeleteAsync(submittedTask);

                return ResponseApiExtension<SubmittedTask>.CreateApiResponseSucess(new ApiResponse<SubmittedTask>("SubmittedTask deletada", submittedTask));

            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }


        }
    }
}