using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;
using SecureIdentity.Password;

namespace ProjetoNotas.WebUi.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
       

        public ProfessorService(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
            
        }

        public async Task<Professor> GetProfessorByIdAsync(int id)
        {
            try
            {
                var professor = await _professorRepository.GetByIdAsync(id);
                if (professor == null)
                {
                    return null;
                }
                return professor;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }

        public async Task<Professor> AddProfessorAsync(EscolaDataContext context, CreateProfessorViewModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //     return _controller.BadRequest("validacao errada");
            // }

            try
            {
                var Nprofessor = new Professor()
                {
                    Nome = model.Nome,
                    Idade = model.Idade,
                    Email = model.Email,
                    Senha = PasswordHasher.Hash(model.Senha),
                    Classes = await context.Classes.Where(classe => model.Classe.Any(x => x.Serie == classe.Serie && x.Turma == classe.Turma)).ToListAsync(),
                    Role = model.Roles
                };
                await _professorRepository.AddAsync(Nprofessor);
                return Nprofessor;
            }

            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }


        }

        public async Task<bool> UpdateProfessorAsync(int id, CreateProfessorViewModel professor)
        {
            try
            {
                var Nprofessor = await _professorRepository.GetByIdAsync(id);
                if (Nprofessor == null)
                {
                    return false;
                }
                Nprofessor.Nome = professor.Nome;
                Nprofessor.Idade = professor.Idade;
                await _professorRepository.UpdateAsync(Nprofessor);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }

        public async Task<bool> DeleteProfessorAsync(int id)
        {
            try
            {
                var professor = await _professorRepository.GetByIdAsync(id);
                if (professor == null)
                {
                    return false;
                }
                await _professorRepository.DeleteAsync(professor);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}