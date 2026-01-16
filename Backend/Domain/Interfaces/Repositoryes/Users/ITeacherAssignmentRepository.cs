using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;

namespace Backend.Domain.Interfaces.Repositoryes.Users
{
    public interface ITeacherAssignmentRepository
    {

        Task<List<TeacherAssignment>> GetAll();
        Task<TeacherAssignment> GetByIdAsync(int teacherId, int classId, int SubjectId);
        Task AddAsync(TeacherAssignment teacher);
        Task UpdateAsync(TeacherAssignment teacher);
        Task DeleteAsync(TeacherAssignment teacher);
    }
}