using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Interfaces.Repositoryes.School;
using Backend.Domain.Interfaces.Services.School;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;

namespace Backend.Application.Services.School
{
    public class TaskSubmissionService : ITaskSubmissionService
    {
        private readonly ITaskSubmissionRepository _tasksubmissionRepository;
        public TaskSubmissionService(ITaskSubmissionRepository tasksubmissionRepository)
        {
            _tasksubmissionRepository = tasksubmissionRepository;

        }
        public async Task<TaskSubmission> GetTaskSubmittedByIdAsync(int studentId, int taskId)
        {
            try
            {
                var mytask = await _tasksubmissionRepository.GetByIdAsync(studentId, taskId);
                if (mytask == null)
                {
                    return null;
                }
                return mytask;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<TaskSubmission> AddTaskSubmittedAsync(CreateSubmittedTaskViewModel model)
        {

            var Mytask = new TaskSubmission()
            {
               StudentId = model.StudentId,
               MyTaskId = model.MyTaskId,
               Score = model.Score

                
            };

            await _tasksubmissionRepository.AddAsync(Mytask);
            return Mytask;

        }
        public async Task<bool> UpdateTaskSubmittedAsync(int studentId,int mytaskId, CreateSubmittedTaskViewModel model)
        {
            try
            {
                var Mytask = await _tasksubmissionRepository.GetByIdAsync(studentId, mytaskId);
                if (Mytask == null)
                {
                    return false;
                }

                Mytask.Score = model.Score;
                _tasksubmissionRepository.UpdateAsync(Mytask);
              
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<bool> DeleteTaskSubmittedAsync(int studentId,int mytaskId)
        {
            try
            {
                var mytask = await _tasksubmissionRepository.GetByIdAsync(studentId, mytaskId );
                if (mytask == null)
                {
                    return false;
                }
                await _tasksubmissionRepository.DeleteAsync(mytask);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}