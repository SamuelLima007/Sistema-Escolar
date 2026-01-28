using ProjetoNotas.Domain.Enums;
using ProjetoNotas.Domain.Models;


namespace ProjetoNotas.Domain.Interfaces.Services.School
{
    public interface IAuthService
    {
        Task<string> ValidateLogin(string username, string password);
        bool LogoutAsync();

        Task<bool> IsEmailRegisteredAsync(string email);


        // Task<bool> RegisterAsync(string username, string password, string email);
        // Task<bool> ResetPasswordAsync(string email, string newPassword);
    }
}