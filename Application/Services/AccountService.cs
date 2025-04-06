using ProjetoNotas.Domain.Enums;
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
        public AccountService(IAccountRepository accountRepository)
        {
           
            _accountRepository = accountRepository;
        }
        public async Task<T> ValidateLogin<T>(string email, string password, UserType userType) where T : User
        {

              User user = null;
                
            switch (userType)
        {
            case UserType.Administrator:
                 user = await _accountRepository.LoginAdminAsync(email);
                 break;
                

            case UserType.Teacher:
                user = await _accountRepository.LoginTeacherAsync(email);
                break;
                

            case UserType.Student:
                user = await _accountRepository.LoginStudentAsync(email);
               break;

            default:
                throw new ArgumentException("Invalid user type.");
        }
        if (user != null)
            {
                var isvalid = PasswordHasher.Verify(user.Password, password);

                if (!isvalid)
                {
                    return null;
                }
                return user as T;
            }         
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