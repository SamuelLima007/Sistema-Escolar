// IUserController.cs
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Models;

using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IUserController
    {
        Task<ActionResult<User>> GetUserByIdAsync(int id);
        Task<ActionResult<User>> AddUserAsync([FromBody] CreateUserViewModel model);
        Task<ActionResult<bool>> UpdateUserAsync(int id, [FromBody] CreateUserViewModel user);
        Task<ActionResult<bool>> DeleteUserAsync(int id);
    }
}