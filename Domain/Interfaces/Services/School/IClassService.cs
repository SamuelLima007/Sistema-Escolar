using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Data;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IClassService
    {
        Task<Class> GetClassByIdAsync(int id);
        Task<Class> AddClassAsync(CreateClassViewModel student);
        Task<bool> UpdateClassAsync(int id, Class classentity);
        Task<bool> DeleteClassAsync(int id);
    }
}