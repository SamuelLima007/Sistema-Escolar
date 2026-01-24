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

namespace ProjetoNotas.Application.Services
{
    public class MyTaskService : IMyTaskService
    {
        private readonly IMyTaskRepository _mytaskRepository;
        public MyTaskService(IMyTaskRepository mytaskRepository)
        {
            _mytaskRepository = mytaskRepository;

        }
        public async Task<MyTask> GetMyTaskByIdAsync(int id)
        {
            try
            {
                var mytask = await _mytaskRepository.GetByIdAsync(id);
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
        public async Task<MyTask> AddMyTaskAsync(CreateMyTaskViewModel model)
        {

            var mytask = new MyTask()
            {
                Name = string.IsNullOrWhiteSpace(model.Name) ? model.Name : model.Name,
                Description = string.IsNullOrWhiteSpace(model.Description) ? model.Description : model.Description,
                CreationDate = model.CreationDate,
                ExpirationDate = model.ExpirationDate,
                ClassId = model.Classid,
                SubjectId = model.SubjectId,
                TeacherId = (int)model.TeacherId,
                score = model.Score
            };

            await _mytaskRepository.AddAsync(mytask);
            return mytask;

        }
        public async Task<bool> UpdateMyTaskAsync(int id, CreateMyTaskViewModel mytask)
        {
            try
            {
                var Nmytask = await _mytaskRepository.GetByIdAsync(id);
                if (Nmytask == null)
                {
                    return false;
                }
                Nmytask.Name = string.IsNullOrWhiteSpace(mytask.Name) ? mytask.Name : mytask.Name;
                Nmytask.Description = string.IsNullOrWhiteSpace(mytask.Description) ? mytask.Description : mytask.Description;
                Nmytask.ExpirationDate = mytask.ExpirationDate;

                await _mytaskRepository.UpdateAsync(Nmytask);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<bool> DeleteMyTaskAsync(int id)
        {
            try
            {
                var mytask = await _mytaskRepository.GetByIdAsync(id);
                if (mytask == null)
                {
                    return false;
                }
                await _mytaskRepository.DeleteAsync(mytask);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}