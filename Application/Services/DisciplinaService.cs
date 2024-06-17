using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;

namespace ProjetoNotas.WebUi.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
    

        public DisciplinaService(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
           
        }


        public async Task<Disciplina> GetDisciplinaByIdAsync(int id)
        {
            try
            {
                var Disciplina = await _disciplinaRepository.GetByIdAsync(id);
                if (Disciplina == null)
                {
                    return null;
                }
                return Disciplina;
            }
             catch (Exception)
        {
            throw new Exception("Falha interna no servidor");
        }
           
        }

        public async Task<Disciplina> AddDisciplinaAsync(EscolaDataContext context, CreateDisciplinaViewModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //     return _controller.BadRequest("validacao errada");
            // }
            var Disciplina = new Disciplina()
            {
                Nome = model.Nome,
               
            };
            await _disciplinaRepository.AddAsync(Disciplina);
            return Disciplina;
        }

        public async Task<bool> UpdateDisciplinaAsync(int id, Disciplina Disciplina)
        {
            try
            {
                var NDisciplina = await _disciplinaRepository.GetByIdAsync(id);
                if (NDisciplina == null)
                {
                    return false;
                }
                NDisciplina.Nome = Disciplina.Nome;
               
                await _disciplinaRepository.UpdateAsync(NDisciplina);
                return true;
            }
            catch (Exception)
            {
                 throw new Exception("Falha interna no servidor");
            }
        }

        public async Task<bool> DeleteDisciplinaAsync(int id)
        {
            try
            {
                var Disciplina = await _disciplinaRepository.GetByIdAsync(id);
                if (Disciplina == null)
                {
                    return false;
                }
                await _disciplinaRepository.DeleteAsync(Disciplina);
                
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}