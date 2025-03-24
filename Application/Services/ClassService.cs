using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoScores.Data;
using ProjetoScores.Domain.Interfaces;
using ProjetoScores.Models;
using ProjetoScores.ViewModels;
namespace ProjetoScores.WebUi.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        public ClassService(IClassRepository studentRepository)
        {
            _classRepository = studentRepository;
        }
        public async Task<Class> GetClassByIdAsync(int id)
        {
            try
            {
                var classentity = await _classRepository.GetByIdAsync(id);
                if (classentity == null)
                {
                    return null;
                }
                return classentity;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<Class> AddClassAsync(EscolaDataContext context, CreateClassViewModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //     return _controller.BadRequest("validacao errada");
            // }
            var classentity = new Class()
            {
                Grade = model.Grade,
                Section = model.Section,

            };
            await _classRepository.AddAsync(classentity);
            return classentity;
        }
        public async Task<bool> UpdateClassAsync(int id, Class classentity)
        {
            try
            {
                var Nclass = await _classRepository.GetByIdAsync(id);
                if (Nclass == null)
                {
                    return false;
                }
                Nclass.Grade = classentity.Grade;
                Nclass.Section = classentity.Section;
                await _classRepository.UpdateAsync(Nclass);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<bool> DeleteClassAsync(int id)
        {
            try
            {
                var classentity = await _classRepository.GetByIdAsync(id);
                if (classentity == null)
                {
                    return false;
                }
                await _classRepository.DeleteAsync(classentity);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}