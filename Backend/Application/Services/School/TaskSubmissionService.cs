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
using ProjetoNotas.Domain.Interfaces.Repositoryes.School;
using ProjetoNotas.Domain.Models;

namespace Backend.Application.Services.School
{
    public class TaskSubmissionService : ITaskSubmissionService
    {
        private readonly ITaskSubmissionRepository _tasksubmissionRepository;
        private readonly IMyTaskRepository _mytaskRepository;
        public TaskSubmissionService(ITaskSubmissionRepository tasksubmissionRepository, IMyTaskRepository mytaskRepository)
        {
            _tasksubmissionRepository = tasksubmissionRepository;
            _mytaskRepository = mytaskRepository;
        }
        public async Task<ApiResponse<TaskSubmission>> GetTaskSubmittedByIdAsync(int studentId, int mytaskId, int loggedId, string loggedRole)
        {
            try
            {
                var mytask = await _mytaskRepository.GetByIdAsync(mytaskId);
                var submittedTask = await _tasksubmissionRepository.GetByIdAsync(studentId, mytaskId);

                if (submittedTask == null)
                {
                    return ResponseApiExtension<TaskSubmission>.CreateApiResponseFail(new ApiResponse<TaskSubmission>("Tarefa inexistente"));
                }

                if (loggedRole == "Teacher" && loggedId != mytask.TeacherId)
                {
                    return ResponseApiExtension<TaskSubmission>.CreateApiResponseFail(new ApiResponse<TaskSubmission>("Permitido apenas para o professor que criou a tarefa", "Forbidden"));
                }

                return ResponseApiExtension<TaskSubmission>.CreateApiResponseSucess(new ApiResponse<TaskSubmission>("Tarefa Encontrada", submittedTask));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<TaskSubmission>> AddTaskSubmittedAsync(CreateSubmittedTaskViewModel model)
        {

            if (model == null)
            {
                return ResponseApiExtension<TaskSubmission>.CreateApiResponseFail(new ApiResponse<TaskSubmission>("Verifique o formato do JSON", new TaskSubmission() { }));
            }

            var Mytask = new TaskSubmission()
            {
                StudentId = model.StudentId,
                MyTaskId = model.MyTaskId,
                Score = model.Score
            };

            await _tasksubmissionRepository.AddAsync(Mytask);
            return ResponseApiExtension<TaskSubmission>.CreateApiResponseSucess(new ApiResponse<TaskSubmission>("Nota da tarefa adicionada com sucesso", Mytask));
        }
        public async Task<ApiResponse<TaskSubmission>> UpdateTaskSubmittedAsync(int studentId, int mytaskId, CreateSubmittedTaskViewModel model, int loggedId, string loggedRole)
        {
            try
            {
                var submittedTask = await _tasksubmissionRepository.GetByIdAsync(studentId, mytaskId);
                var mytask = await _mytaskRepository.GetByIdAsync(mytaskId);
                if (model == null)
                {
                    return ResponseApiExtension<TaskSubmission>.CreateApiResponseFail(new ApiResponse<TaskSubmission>("Verifique o formato do JSON", new TaskSubmission() { }));
                }

                if (submittedTask == null)
                {
                    return ResponseApiExtension<TaskSubmission>.CreateApiResponseFail(new ApiResponse<TaskSubmission>("Tarefa não encontrada"));
                }

                else if (loggedRole == "Teacher" && loggedId != mytask.TeacherId)
                {
                    return ResponseApiExtension<TaskSubmission>.CreateApiResponseFail(new ApiResponse<TaskSubmission>("Apenas o professor que criou a tarefa pode atualizar a nota"));
                }

                submittedTask.Score = model.Score;
                _tasksubmissionRepository.UpdateAsync(submittedTask);

                return ResponseApiExtension<TaskSubmission>.CreateApiResponseSucess(new ApiResponse<TaskSubmission>("Nota atualizada com sucesso", submittedTask)); ;


            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<TaskSubmission>> DeleteTaskSubmittedAsync(int studentId, int mytaskId, int loggedId, string loggedRole)
        {
            try
            {
                var submittedTask = await _tasksubmissionRepository.GetByIdAsync(studentId, mytaskId);
                var mytask = await _mytaskRepository.GetByIdAsync(mytaskId);
                if (submittedTask == null)
                {
                    return ResponseApiExtension<TaskSubmission>.CreateApiResponseFail(new ApiResponse<TaskSubmission>("Tarefa inexistente"));
                }
                else if (loggedRole == "Teacher" && loggedId != mytask.TeacherId)
                {
                    return ResponseApiExtension<TaskSubmission>.CreateApiResponseFail(new ApiResponse<TaskSubmission>("Apenas o professor que criou a tarefa pode fazer a exclusão"));
                }

                await _tasksubmissionRepository.DeleteAsync(submittedTask);

                return ResponseApiExtension<TaskSubmission>.CreateApiResponseSucess(new ApiResponse<TaskSubmission>("TaskSubmitted deletada", submittedTask));

            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }


        }
    }
}