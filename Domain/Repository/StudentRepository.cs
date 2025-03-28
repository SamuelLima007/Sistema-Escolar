using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoScores.Data;
using ProjetoScores.Domain.Interfaces;
using ProjetoScores.Models;

namespace ProjetoScores.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EscolaDataContext _context;
        public StudentRepository(EscolaDataContext context)
        {
            _context = context;
        }
        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);

        }
        public async Task AddAsync(Student student)
        {
            try
            {

                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
              
                Console.WriteLine($"Erro ao salvar no banco de dados: {ex.InnerException?.Message}");
                throw; 
            }
        }
        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}