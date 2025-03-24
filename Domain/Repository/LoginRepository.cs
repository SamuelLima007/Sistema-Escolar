using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoScores.Data;
using ProjetoScores.Models;
using SecureIdentity.Password;

namespace ProjetoScores.Repository
{
    public class LoginRepository
    {
        private readonly EscolaDataContext _context;
        public LoginRepository(EscolaDataContext context)
        {
            _context = context;
        }
        public async Task<dynamic> LoginStudentAsync(string email, string password)
        {
            var user = await _context.Students.FirstOrDefaultAsync(x => x.Email == email);

            if (user != null)
            {
                var isvalid = PasswordHasher.Verify(user.Password, password);

                if (!isvalid)
                {
                    return null;
                }
                return user;
            }
            return null;
        }
        public async Task<dynamic> LoginAdminAsync(string email, string password)
        {
            var user = await _context.Administratores.FirstOrDefaultAsync(x => x.Email == email);
            if (user != null)
            {
                var isvalid = PasswordHasher.Verify(user.Password, password);

                if (!isvalid)
                {
                    return null;
                }
                return user;
            }
            return null;
        }
        public async Task<dynamic> LoginTeacherAsync(string email, string password)
        {
            var user = await _context.Teacheres.FirstOrDefaultAsync(x => x.Email == email);
            if (user != null)
            {
                var isvalid = PasswordHasher.Verify(user.Password, password);

                if (!isvalid)
                {
                    return null;
                }
                return user;
            }
            return null;
        }
    }
}