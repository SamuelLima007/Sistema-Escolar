using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;
using SecureIdentity.Password;

namespace ProjetoNotas.WebUi.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly IAdministradorRepository _administradorRepository;
        public AdministradorService(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public async Task<Administrador> GetAdministradorByIdAsync(int id)
        {
            try
            {
                var Administrador = await _administradorRepository.GetByIdAsync(id);
                if (Administrador == null)
                {
                    return null;
                }
                return Administrador;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<Administrador> AddAdministradorAsync(EscolaDataContext context, CreateAdministradorViewModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //     return _controller.BadRequest("validacao errada");
            // }
            var administrador = new Administrador()
            {
                Nome = model.Nome,

                Email = model.Email,
                Senha = PasswordHasher.Hash(model.Senha),

                Role = model.Roles
            };
            await _administradorRepository.AddAsync(administrador);
            return administrador;
        }
        public async Task<bool> UpdateAdministradorAsync(int id, Administrador Administrador)
        {
            try
            {
                var Nadministrador = await _administradorRepository.GetByIdAsync(id);
                if (Nadministrador == null)
                {
                    return false;
                }
                Nadministrador.Nome = Administrador.Nome;
                Nadministrador.Email = Administrador.Email;
                Nadministrador.Senha = Administrador.Senha;
                await _administradorRepository.UpdateAsync(Nadministrador);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<bool> DeleteAdministradorAsync(int id)
        {
            try
            {
                var administrador = await _administradorRepository.GetByIdAsync(id);
                if (administrador == null)
                {
                    return false;
                }
                await _administradorRepository.DeleteAsync(administrador);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}