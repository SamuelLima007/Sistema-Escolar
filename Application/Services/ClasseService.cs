using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;
namespace ProjetoNotas.WebUi.Services
{
    public class ClasseService : IClasseService
    {
        private readonly IClasseRepository _classeRepository;
        public ClasseService(IClasseRepository alunoRepository)
        {
            _classeRepository = alunoRepository;
        }
        public async Task<Classe> GetClasseByIdAsync(int id)
        {
            try
            {
                var classe = await _classeRepository.GetByIdAsync(id);
                if (classe == null)
                {
                    return null;
                }
                return classe;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<Classe> AddClasseAsync(EscolaDataContext context, CreateClasseViewModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //     return _controller.BadRequest("validacao errada");
            // }
            var classe = new Classe()
            {
                Serie = model.Serie,
                Turma = model.Turma,

            };
            await _classeRepository.AddAsync(classe);
            return classe;
        }
        public async Task<bool> UpdateClasseAsync(int id, Classe classe)
        {
            try
            {
                var Nclasse = await _classeRepository.GetByIdAsync(id);
                if (Nclasse == null)
                {
                    return false;
                }
                Nclasse.Serie = classe.Serie;
                Nclasse.Turma = classe.Turma;
                await _classeRepository.UpdateAsync(Nclasse);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<bool> DeleteClasseAsync(int id)
        {
            try
            {
                var classe = await _classeRepository.GetByIdAsync(id);
                if (classe == null)
                {
                    return false;
                }
                await _classeRepository.DeleteAsync(classe);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}