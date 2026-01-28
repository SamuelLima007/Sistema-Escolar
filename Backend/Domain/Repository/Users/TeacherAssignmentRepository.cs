using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Interfaces.Repositoryes.Users;
using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Data;

namespace Backend.Domain.Repository.School
{
    public class TeacherAssignmentRepository : ITeacherAssignmentRepository
    {
        private readonly EscolaDataContext _context;
        public TeacherAssignmentRepository(EscolaDataContext context)
        {
            _context = context;
        }

        public async Task<List<TeacherAssignment>> GetAll()
        {
            return await _context.TeacherAssignments.ToListAsync();
        }
        public async Task AddAsync(TeacherAssignment teacherAssignment)
        {
            await _context.TeacherAssignments.AddAsync(teacherAssignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TeacherAssignment teacherAssignment)
        {
            _context.TeacherAssignments.Remove(teacherAssignment);
            await _context.SaveChangesAsync();
        }
        public async Task<TeacherAssignment> GetByIdAsync(int teacherId, int classId, int subjectId)
        {
            return await _context.TeacherAssignments.FirstOrDefaultAsync
            (x => x.TeacherId == teacherId &&
             x.SubjectId == subjectId &&
             x.ClassId == classId
            );
        }
        public async Task UpdateAsync(TeacherAssignment teacherAssignment)
        {
            _context.TeacherAssignments.Update(teacherAssignment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindAssignment(int classId, int subjectId, int teacherId)
        {
             return await _context.TeacherAssignments.AnyAsync
            (x => x.TeacherId == teacherId &&
             x.SubjectId == subjectId &&
             x.ClassId == classId
            );
        }
    }
}