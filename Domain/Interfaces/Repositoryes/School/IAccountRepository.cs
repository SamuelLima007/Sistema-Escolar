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
        Task<Student> LoginStudentAsync(string username, string password);
        Task<Administrator> LoginAdminAsync(string username, string password);
        Task<Teacher> LoginTeacherAsync(string username, string password);

    }
}