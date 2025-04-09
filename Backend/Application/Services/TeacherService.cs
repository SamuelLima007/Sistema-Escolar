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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IClassRepository _classRepository;
        public TeacherService(ITeacherRepository teacherRepository, IClassRepository classRepository)
        {
            _teacherRepository = teacherRepository;
            _classRepository = classRepository;

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
        public async Task<Teacher> AddTeacherAsync(CreateTeacherViewModel model, int id)
{
    try
    {

        var classentity = await _classRepository.GetByIdAsync(id);
       
          var classes = new List<Class>();
          classes.Add(classentity);
        var newTeacher = new Teacher()
        {
            Name = model.Name,
            Age = model.Age,
            Email = model.Email,
            Password = PasswordHasher.Hash(model.Password),
            Classs = classes, 
            Role = model.Roles
        };

        await _teacherRepository.AddAsync(newTeacher);
        return newTeacher;
    }
    catch (Exception ex)
    {
        throw new Exception("Falha ao adicionar o professor.", ex);
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