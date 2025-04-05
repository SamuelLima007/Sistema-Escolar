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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public readonly EscolaDataContext _context;
        public StudentService(IStudentRepository studentRepository, EscolaDataContext context)
        {
            _studentRepository = studentRepository;
            _context = context;

        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            try
            {
                var student = await _studentRepository.GetByIdAsync(id);
                if (student == null)
                {
                    return null;
                }
                return student;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }

        }
        public async Task<Student> AddStudentAsync(CreateStudentViewModel model)
        {
            // if (!ModelState.IsValid)
            // {
            //     return _controller.BadRequest("validacao errada");
            // }
            var classentity = await _context.Classs.FirstOrDefaultAsync();
           

            var student = new Student()
            {
                Name = model.Name,
                Age = model.Age,
                Email = model.Email,
                Password = PasswordHasher.Hash(model.Password),
                Class = classentity,
                Role = model.Roles
            };
            try
            {
            await _studentRepository.AddAsync(student);
            return student;
             }
            catch (DbUpdateException ex)
            {
              
                Console.WriteLine($"Erro ao salvar no banco de dados: {ex.InnerException?.Message}");
                throw; 
            }
        }
        public async Task<bool> UpdateStudentAsync(int id, CreateStudentViewModel student)
        {
            try
            {
                var Nstudent = await _studentRepository.GetByIdAsync(id);
                if (Nstudent == null)
                {
                    return false;
                }
                Nstudent.Name = student.Name;
                Nstudent.Age = student.Age;
                await _studentRepository.UpdateAsync(Nstudent);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<bool> DeleteStudentAsync(int id)
        {
            try
            {
                var student = await _studentRepository.GetByIdAsync(id);
                if (student == null)
                {
                    return false;
                }
                await _studentRepository.DeleteAsync(student);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}