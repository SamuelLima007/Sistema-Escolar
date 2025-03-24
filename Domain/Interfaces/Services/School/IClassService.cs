using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoScores.Data;
using ProjetoScores.Models;
using ProjetoScores.ViewModels;

namespace ProjetoScores.Domain.Interfaces
{
    public interface IClassService
    {
        Task<Class> GetClassByIdAsync(int id);
        Task<Class> AddClassAsync(EscolaDataContext context, CreateClassViewModel student);
        Task<bool> UpdateClassAsync(int id, Class classentity);
        Task<bool> DeleteClassAsync(int id);
    }
}