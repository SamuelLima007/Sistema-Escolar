using ProjetoNotas.Domain.Enums;
using ProjetoNotas.Domain.Models;


namespace ProjetoNotas.Domain.Interfaces.Services.School
{
    public interface IAccountService
    {
        Task<T> ValidateLogin<T>(string username, string password, UserType userType) where T: User;
        bool LogoutAsync();
        // Task<bool> RegisterAsync(string username, string password, string email);
        // Task<bool> ResetPasswordAsync(string email, string newPassword);
    }
}