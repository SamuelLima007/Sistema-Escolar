using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Extensions;
using Backend.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;

using ProjetoNotas.ViewModels;
using SecureIdentity.Password;
namespace ProjetoNotas.WebUi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClassRepository _classRepository;


        public UserService(IUserRepository userRepository, IClassRepository classRepository)
        {
            _userRepository = userRepository;
            _classRepository = classRepository;


        }

        public async Task<ApiResponse<UserResponse>> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);



                if (user == null)
                {
                    return ResponseApiExtension<UserResponse>.CreateApiResponseFail(new ApiResponse<UserResponse>("Usuario inexistente"));
                }
              
                var UserClass = await _classRepository.GetByIdAsync(2);
                Console.Write(UserClass);
                var UseResponse = new UserResponse
                {
                    Name = user.Name,
                    Id = user.Id,
                    Role = user.Role,
                    ClassId = user.ClassId,
                    Class = UserClass.Grade,
                    Score1 = user.Score1,
                    Score2 = user.Score2,
                    Score3 = user.Score3,
                    Score4 = user.Score4,

                };
             
                return ResponseApiExtension<UserResponse>.CreateApiResponseSucess(new ApiResponse<UserResponse>("Usuario encontrado", UseResponse));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }

        }
        public async Task<ApiResponse<User>> AddUserAsync(CreateUserViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return ResponseApiExtension<User>.CreateApiResponseFail(new ApiResponse<User>("Verifique o formato do JSON", new User() { }));
                }

                var user = new User()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = PasswordHasher.Hash(model.Password),
                    Role = model.Role,
                    ClassId = model.ClassId
                };

                await _userRepository.AddAsync(user);
                return ResponseApiExtension<User>.CreateApiResponseSucess(new ApiResponse<User>("Usuario adicionado com sucesso", user));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<User>> UpdateUserAsync(int id, CreateUserViewModel model)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (model == null)
                {
                    return ResponseApiExtension<User>.CreateApiResponseFail(new ApiResponse<User>("Verifique o formato do JSON", new User() { }));
                }

                if (user == null)
                {
                    return ResponseApiExtension<User>.CreateApiResponseFail(new ApiResponse<User>("Usuario não encontrado"));
                }
                if (model.Password != null) model.Password = PasswordHasher.Hash(model.Password);
                user.Update(model.Name, model.Email, model.Password);

                await _userRepository.UpdateAsync(user);
                return ResponseApiExtension<User>.CreateApiResponseSucess(new ApiResponse<User>("Usuario atualizado com sucesso", user)); ;
            }

            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<User>> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    return ResponseApiExtension<User>.CreateApiResponseFail(new ApiResponse<User>("Usuario inexistente"));
                }
                await _userRepository.DeleteAsync(user);
                return ResponseApiExtension<User>.CreateApiResponseSucess(new ApiResponse<User>("Usuario deletado com sucesso", user));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }

        }
    }
}