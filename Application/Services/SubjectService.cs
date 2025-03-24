using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoScores.Data;
using ProjetoScores.Domain.Interfaces;
using ProjetoScores.Domain.Models;
using ProjetoScores.Domain.ViewModels;

namespace ProjetoScores.WebUi.Services
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
        public async Task<Subject> AddSubjectAsync(EscolaDataContext context, CreateSubjectViewModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //     return _controller.BadRequest("validacao errada");
            // }
            var Subject = new Subject()
            {
                Name = model.Name,

            };
            await _subjectRepository.AddAsync(Subject);
            return Subject;
        }
        public async Task<bool> UpdateSubjectAsync(int id, Subject Subject)
        {
            try
            {
                var NSubject = await _subjectRepository.GetByIdAsync(id);
                if (NSubject == null)
                {
                    return false;
                }
                NSubject.Name = Subject.Name;

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