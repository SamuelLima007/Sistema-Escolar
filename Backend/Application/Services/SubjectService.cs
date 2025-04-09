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
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;

        }
        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            try
            {
                var Subject = await _subjectRepository.GetByIdAsync(id);
                if (Subject == null)
                {
                  return null;
                }
                return Subject;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<Subject> AddSubjectAsync(CreateSubjectViewModel model)
        {
          
          try
           {
            var Subject = new Subject()
            {
                Name = model.Name,
            
            };
            await _subjectRepository.AddAsync(Subject);
            return Subject;
             }
          catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }

        }
        public async Task<bool> UpdateSubjectAsync(int id, CreateSubjectViewModel subject)
        {
            try
            {
                var NSubject = await _subjectRepository.GetByIdAsync(id);
                if (NSubject == null)
                {
                    return false;
                }
                NSubject.Name = subject.Name;

                await _subjectRepository.UpdateAsync(NSubject);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<bool> DeleteSubjectAsync(int id)
        {
            try
            {
                var Subject = await _subjectRepository.GetByIdAsync(id);
                if (Subject == null)
                {
                    return false;
                }
                await _subjectRepository.DeleteAsync(Subject);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }

            
        }
    }
}