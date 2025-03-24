using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoScores.Data;
using ProjetoScores.Domain.Interfaces;
using ProjetoScores.Models;
using ProjetoScores.ViewModels;
using SecureIdentity.Password;

namespace ProjetoScores.WebUi.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;

        }
        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            try
            {
                var teacher = await _teacherRepository.GetByIdAsync(id);
                if (teacher == null)
                {
                    return null;
                }
                return teacher;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<Teacher> AddTeacherAsync(EscolaDataContext context, CreateTeacherViewModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //     return _controller.BadRequest("validacao errada");
            // }
            try
            {
                var Nteacher = new Teacher()
                {
                    Name = model.Name,
                    Age = model.Age,
                    Email = model.Email,
                    Password = PasswordHasher.Hash(model.Password),
                    Classs = await context.Classs.Where(classentity => model.Class.Any(x => x.Grade == classentity.Grade && x.Section == classentity.Section)).ToListAsync(),
                    Role = model.Roles
                };
                await _teacherRepository.AddAsync(Nteacher);
                return Nteacher;
            }

            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<bool> UpdateTeacherAsync(int id, CreateTeacherViewModel teacher)
        {
            try
            {
                var Nteacher = await _teacherRepository.GetByIdAsync(id);
                if (Nteacher == null)
                {
                    return false;
                }
                Nteacher.Name = teacher.Name;
                Nteacher.Age = teacher.Age;
                await _teacherRepository.UpdateAsync(Nteacher);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<bool> DeleteTeacherAsync(int id)
        {
            try
            {
                var teacher = await _teacherRepository.GetByIdAsync(id);
                if (teacher == null)
                {
                    return false;
                }
                await _teacherRepository.DeleteAsync(teacher);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}