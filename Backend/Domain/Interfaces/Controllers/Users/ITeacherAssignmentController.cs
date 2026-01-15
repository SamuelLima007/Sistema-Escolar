using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Domain.Interfaces.Controllers.Users
{
    public interface ITeacherAssignmentController
    {
         Task<ActionResult<TeacherAssignment>> GetTeacherAssignmentByIdAsync(TeacherAssignment model);
        Task<ActionResult<TeacherAssignment>> AddTeacherAssignmentAsync(TeacherAssignment model);
        Task<ActionResult<bool>> UpdateTeacherAssignmentAsync(TeacherAssignment model);
        Task<ActionResult<bool>> DeleteTeacherAssignmentAsync(TeacherAssignment model);
    }
}