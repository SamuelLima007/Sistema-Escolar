using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Models;

using ProjetoNotas.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<UserResponse>> GetUserByIdAsync(int id);
        Task<ApiResponse<User>> AddUserAsync(CreateUserViewModel user);
        Task<ApiResponse<User>> UpdateUserAsync(int id, CreateUserViewModel user);
        Task<ApiResponse<User>> DeleteUserAsync(int id);

        Task<ApiResponse<UserResponse>> GetStudentByIdAsync(int id);
        Task<ApiResponse<UserResponse>> GetTeacherByClassAndSubject( int subjectId, int classId);
    }
}