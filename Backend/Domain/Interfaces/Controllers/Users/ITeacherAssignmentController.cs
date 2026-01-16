using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Domain.Interfaces.Controllers.Users
{
    public interface ITeacherAssignmentController
    {
        Task<ActionResult<TeacherAssignment>> GetTeacherAssignmentByIdAsync(int teacherId, int classId, int SubjectId);
        Task<ActionResult<TeacherAssignment>> AddTeacherAssignmentAsync(TeacherAssignment model);
        Task<ActionResult<bool>> UpdateTeacherAssignmentAsync(int teacherId, int classId, int SubjectId, CreateTeacherAssignmentViewModel model);
        Task<ActionResult<bool>> DeleteTeacherAssignmentAsync(int teacherId, int classId, int SubjectId);
    }
}