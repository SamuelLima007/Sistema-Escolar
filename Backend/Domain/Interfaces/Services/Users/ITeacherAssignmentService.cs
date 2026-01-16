using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;

namespace Backend.Domain.Interfaces.Services.Users
{
    public interface ITeacherAssignmentService
    {
        Task<TeacherAssignment> GetTeacherAssignmentByIdAsync(int teacherId, int classId, int SubjectId);
        Task<TeacherAssignment> AddTeacherAssignmentAsync(TeacherAssignment model);
        Task<bool> UpdateTeacherAssignmentAsync(TeacherAssignment model);
        Task<bool> DeleteTeacherAssignmentAsync(TeacherAssignment model);
    }
}