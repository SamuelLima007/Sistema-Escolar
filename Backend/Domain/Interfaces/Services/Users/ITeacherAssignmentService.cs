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
        Task<ApiResponse<TeacherAssignment>> GetTeacherAssignmentByIdAsync(int teacherId, int classId, int subjectId);
        Task<ApiResponse<TeacherAssignment>> AddTeacherAssignmentAsync(TeacherAssignment model);
        Task<ApiResponse<TeacherAssignment>> UpdateTeacherAssignmentAsync(int teacherId, int classId, int subjectId, CreateTeacherAssignmentViewModel model);
        Task<ApiResponse<TeacherAssignment>> DeleteTeacherAssignmentAsync(int teacherId, int classId, int subjectId);
    }
}