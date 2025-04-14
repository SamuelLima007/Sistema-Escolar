using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.Domain.Interfaces.Repositoryes.School
{
    public interface IMyTaskRepository
    {

        Task<List<MyTask>> GetAll();
        Task<MyTask> GetByIdAsync(int id);
        Task AddAsync(MyTask mytask);
        Task UpdateAsync(MyTask mytask);
        Task DeleteAsync(MyTask mytask);
    }
}