using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;
using SecureIdentity.Password;

namespace ProjetoNotas.WebUi.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IAdministratorRepository _administratorRepository;
        public AdministratorService(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }
        public async Task<Administrator> GetAdministratorByIdAsync(int id)
        {
            try
            {
                var Administrator = await _administratorRepository.GetByIdAsync(id);
                if (Administrator == null)
                {
                    return null;
                }
                return Administrator;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<Administrator> AddAdministratorAsync(CreateAdministratorViewModel model)
        {
            var administrator = new Administrator()
            {
                Name = model.Name,
                Email = model.Email,
                Password = PasswordHasher.Hash(model.Password),
                Role = model.Roles
            };
            await _administratorRepository.AddAsync(administrator);
            return administrator;
        }
        public async Task<bool> UpdateAdministratorAsync(int id, CreateAdministratorViewModel Administrator)
        {
            try
            {
                var Nadministrator = await _administratorRepository.GetByIdAsync(id);
                if (Nadministrator == null)
                {
                    return false;
                }
                Nadministrator.Name = Administrator.Name;
                Nadministrator.Email = Administrator.Email;
                Nadministrator.Password = Administrator.Password;
                await _administratorRepository.UpdateAsync(Nadministrator);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<bool> DeleteAdministratorAsync(int id)
        {
            try
            {
                var administrator = await _administratorRepository.GetByIdAsync(id);
                if (administrator == null)
                {
                    return false;
                }
                await _administratorRepository.DeleteAsync(administrator);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}