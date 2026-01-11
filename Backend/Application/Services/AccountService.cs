using ProjetoNotas.Domain.Enums;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Interfaces.Repositoryes.School;
using ProjetoNotas.Domain.Interfaces.Services.School;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Repository;
using SecureIdentity.Password;

namespace ProjetoNotas.Application.Services
{


    public class AccountService : IAccountService
    {


        private readonly IAccountRepository _accountRepository;
        private readonly ITokenService _tokenservice;
        public AccountService(IAccountRepository accountRepository, ITokenService tokenservice)
        {

            _accountRepository = accountRepository;
            _tokenservice = tokenservice;
        }
        public async Task<string> ValidateLogin(string email, string password, UserType userType)
        {
            if (!await _accountRepository.IsEmailRegisteredAsync(email))
            {
                var user = await _accountRepository.LoginUserAsync(email);
                var isvalid = PasswordHasher.Verify(user.Password, password);
                if (!isvalid)
                {
                    return null;
                }
                return _tokenservice.GenerateToken(user);
            }
            return null;
        }
        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            return await _accountRepository.IsEmailRegisteredAsync(email);
        }

        public bool LogoutAsync()
        {
            return false;
        }
    }
}