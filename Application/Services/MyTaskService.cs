using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Interfaces.Repositoryes.School;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces.Services.School;

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
         
            try
            {
                var Nmytask = new MyTask()
                {
                    Name = model.Name,
                    Description = model.Description,
                    DueDate = model.DueDate,
                };
                await _mytaskRepository.AddAsync(Nmytask);
                return Nmytask;
            }

            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
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
                Nmytask.Name = mytask.Name;
                Nmytask.Description = mytask.Description;
                Nmytask.DueDate = mytask.DueDate;
                
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