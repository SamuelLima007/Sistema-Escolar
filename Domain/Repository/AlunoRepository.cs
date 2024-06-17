using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Models;

namespace ProjetoNotas.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
    
        private readonly EscolaDataContext _context;

        public AlunoRepository(EscolaDataContext context)
        {
            _context = context;
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            return await _context.Alunos.FirstOrDefaultAsync(x => x.AlunoId == id);
            
        }

        public async Task AddAsync(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }

        
    }
}