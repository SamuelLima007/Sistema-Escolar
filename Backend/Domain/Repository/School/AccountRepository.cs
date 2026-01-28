using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Domain.Interfaces.Repositoryes.School;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Models;

using SecureIdentity.Password;

namespace ProjetoNotas.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly EscolaDataContext _context;
        public AuthRepository(EscolaDataContext context)
        {
            _context = context;
        }
        public async Task<User> LoginUserAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);


        }
        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);


        }
    }
}