using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;
using SecureIdentity.Password;
namespace ProjetoNotas.WebUi.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public readonly EscolaDataContext _context;
        public AlunoService(IAlunoRepository alunoRepository, EscolaDataContext context)
        {
            _alunoRepository = alunoRepository;
            _context = context;

        }
        public async Task<Aluno> GetAlunoByIdAsync(int id)
        {
            try
            {
                var aluno = await _alunoRepository.GetByIdAsync(id);
                if (aluno == null)
                {
                    return null;
                }
                return aluno;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }

        }
        public async Task<Aluno> AddAlunoAsync(CreateAlunoViewModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //     return _controller.BadRequest("validacao errada");
            // }
            var classe = await _context.Classes.FirstOrDefaultAsync();
            if (classe == null)
            {
                throw new InvalidOperationException("Classe não encontrada.");
            }

            var aluno = new Aluno()
            {
                Nome = model.Nome,
                Idade = model.Idade,
                Email = model.Email,
                Senha = PasswordHasher.Hash(model.Senha),
                Classe = classe,
                Role = model.Roles
            };
            await _alunoRepository.AddAsync(aluno);
            return aluno;
        }
        public async Task<bool> UpdateAlunoAsync(int id, Aluno aluno)
        {
            try
            {
                var Naluno = await _alunoRepository.GetByIdAsync(id);
                if (Naluno == null)
                {
                    return false;
                }
                Naluno.Nome = aluno.Nome;
                Naluno.Idade = aluno.Idade;
                await _alunoRepository.UpdateAsync(Naluno);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<bool> DeleteAlunoAsync(int id)
        {
            try
            {
                var aluno = await _alunoRepository.GetByIdAsync(id);
                if (aluno == null)
                {
                    return false;
                }
                await _alunoRepository.DeleteAsync(aluno);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}