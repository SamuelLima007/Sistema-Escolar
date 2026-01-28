using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;


namespace ProjetoNotas.Domain.Interfaces.Repositoryes.School
{
    public interface IAuthRepository
    {
        Task<User> LoginUserAsync(string email);
       
        Task<bool> IsEmailRegisteredAsync(string email);

    }
}