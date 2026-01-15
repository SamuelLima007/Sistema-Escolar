using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                Console.WriteLine("teste");
                if (user == null)
                {
                    return null;
                }
                Console.WriteLine("teste");
                return user;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }

        }
        public async Task<User> AddUserAsync(CreateUserViewModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //     return _controller.BadRequest("validacao errada");
            // }
            var classentity = await _context.Classs.FirstOrDefaultAsync();
            var user = new User()
            {
                Name = model.Name,
                Email = model.Email,
                Password = PasswordHasher.Hash(model.Password),
                Role = model.Role,
                ClassId = model.ClassId
            };
            try
            {
                await _userRepository.AddAsync(user);
                return user;
            }
            catch (DbUpdateException ex)
            {

                Console.WriteLine($"Erro ao salvar no banco de dados: {ex.InnerException?.Message}");
                throw;
            }
        }
        public async Task<bool> UpdateUserAsync(int id, CreateUserViewModel model)
        {
            try
            {

                var user = await _userRepository.GetByIdAsync(id);


                if (user == null)
                {
                    return false;
                }
                user.Name = string.IsNullOrWhiteSpace(model.Name) ? user.Name : model.Name;
                user.Email = string.IsNullOrWhiteSpace(model.Email) ? user.Email : model.Email;
                user.Password = string.IsNullOrWhiteSpace(model.Password) ? user.Password : model.Password;


                await _userRepository.UpdateAsync(user);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    return false;
                }
                await _userRepository.DeleteAsync(user);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }


    }
}