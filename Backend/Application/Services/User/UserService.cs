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

        public readonly EscolaDataContext _context;
        public UserService(IUserRepository userRepository, EscolaDataContext context)
        {
            _userRepository = userRepository;
            _context = context;

        }


        public async Task<ApiResponse<User>> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    return ResponseApiExtension<User>.CreateApiResponseFail(new ApiResponse<User>("Usuario inexistente"));
                }
                return ResponseApiExtension<User>.CreateApiResponseSucess(new ApiResponse<User>("Usuario encontrado", user));
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
                user.Name = string.IsNullOrWhiteSpace(model.Name) ? user.Name : model.Name;
                user.Email = string.IsNullOrWhiteSpace(model.Email) ? user.Email : model.Email;
                user.Password = string.IsNullOrWhiteSpace(model.Password) ? user.Password : model.Password;

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