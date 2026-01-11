using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Models;

using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(CreateUserViewModel user);
        Task<bool> UpdateUserAsync(int id, CreateUserViewModel user);
        Task<bool> DeleteUserAsync(int id);
    }
}