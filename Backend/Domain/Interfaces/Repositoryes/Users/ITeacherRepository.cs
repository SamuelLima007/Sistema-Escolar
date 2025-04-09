using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Models;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface ITeacherRepository
    {
         Task<Teacher> GetByIdAsync(int id);
        Task AddAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task DeleteAsync(Teacher teacher);
    }
}