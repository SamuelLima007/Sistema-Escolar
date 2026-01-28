using ProjetoNotas.Domain.Enums;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Interfaces.Repositoryes.School;
using ProjetoNotas.Domain.Interfaces.Services.School;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Repository;
using SecureIdentity.Password;

namespace ProjetoNotas.Application.Services
{


    public class AuthService : IAuthService
    {


        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenservice;
        public AuthService(IAuthRepository authRepository, ITokenService tokenservice)
        {

            _authRepository = authRepository;
            _tokenservice = tokenservice;
        }
        public async Task<string> ValidateLogin(string email, string password)
        {
            if (await _authRepository.IsEmailRegisteredAsync(email))
            {
                var user = await _authRepository.LoginUserAsync(email);

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
            return await _authRepository.IsEmailRegisteredAsync(email);
        }

        public bool LogoutAsync()
        {
            return false;
        }
    }
}