using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Data;
using ProjetoNotas.Models;
using SecureIdentity.Password;

namespace ProjetoNotas.Repository
{
    public class LoginRepository
    {
        private readonly EscolaDataContext _context;
        public LoginRepository(EscolaDataContext context)
        {
            _context = context;
        }
        public async Task<dynamic> LoginAlunoAsync(string email, string senha)
        {
            var user = await _context.Alunos.FirstOrDefaultAsync(x => x.Email == email);

            if (user != null)
            {
                var isvalid = PasswordHasher.Verify(user.Senha, senha);

                if (!isvalid)
                {
                    return null;
                }
                return user;
            }
            return null;
        }
        public async Task<dynamic> LoginAdminAsync(string email, string senha)
        {
            var user = await _context.Administradores.FirstOrDefaultAsync(x => x.Email == email);
            if (user != null)
            {
                var isvalid = PasswordHasher.Verify(user.Senha, senha);

                if (!isvalid)
                {
                    return null;
                }
                return user;
            }
            return null;
        }
        public async Task<dynamic> LoginProfessorAsync(string email, string senha)
        {
            var user = await _context.Professores.FirstOrDefaultAsync(x => x.Email == email);
            if (user != null)
            {
                var isvalid = PasswordHasher.Verify(user.Senha, senha);

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