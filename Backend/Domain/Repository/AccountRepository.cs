using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Domain.Interfaces.Repositoryes.School;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Models;
using SecureIdentity.Password;

namespace ProjetoNotas.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EscolaDataContext _context;
        public AccountRepository(EscolaDataContext context)
        {
            _context = context;
        }
        public async Task<Student> LoginStudentAsync(string email)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.Email == email);

           
        }
        public async Task<Administrator> LoginAdminAsync(string email)
        {

             return await _context.Administrators.FirstOrDefaultAsync(x => x.Email == email);
         
        }
        public async Task<Teacher> LoginTeacherAsync(string email)
        {
           return await _context.Teachers.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> IsEmailRegisteredAsync(string email)
         {
           return await _context.Students.AnyAsync(x => x.Email == email) ||
           await _context.Administrators.AnyAsync(x => x.Email == email) ||
           await _context.Teachers.AnyAsync(x => x.Email == email);
         }
    }
}