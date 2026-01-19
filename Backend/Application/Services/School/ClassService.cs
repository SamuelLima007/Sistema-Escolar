using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;

using ProjetoNotas.ViewModels;
namespace ProjetoNotas.WebUi.Services
{
    
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
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
        public async Task<Class> AddClassAsync(CreateClassViewModel model)
        {
            if (model != null)
            {
                var classentity = new Class()
                {
                    Grade = model.Grade,
                };
                await _classRepository.AddAsync(classentity);
                return classentity;
            }
        
            return null;
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