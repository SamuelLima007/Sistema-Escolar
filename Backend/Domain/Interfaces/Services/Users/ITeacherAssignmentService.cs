using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;

namespace Backend.Domain.Interfaces.Services.Users
{
    public interface ITeacherAssignmentService
    {
        Task<TeacherAssignment> GetTeacherAssignmentByIdAsync(int teacherId, int classId, int SubjectId);
        Task<TeacherAssignment> AddTeacherAssignmentAsync(TeacherAssignment model);
        Task<bool> UpdateTeacherAssignmentAsync(int teacherId, int classId, int SubjectId, CreateTeacherAssignmentViewModel model);
        Task<bool> DeleteTeacherAssignmentAsync(int teacherId, int classId, int SubjectId);
    }
}