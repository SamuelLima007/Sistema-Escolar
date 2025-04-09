using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Models;

namespace ProjetoNotas.Domain.Interfaces.Repositoryes.School
{
    public interface IAccountRepository
    {
        Task<Student> LoginStudentAsync(string email);
        Task<Administrator> LoginAdminAsync(string email);
        Task<Teacher> LoginTeacherAsync(string email);
        Task<bool> IsEmailRegisteredAsync(string email);

    }
}