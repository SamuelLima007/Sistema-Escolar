using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Interfaces.Repositoryes.Users;
using Backend.Domain.Interfaces.Services.Users;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;

namespace Backend.Application.Services.School
{
    public class TeacherAssignmentService : ITeacherAssignmentService
    {
        private readonly ITeacherAssignmentRepository _teacherassignmentRepository;
        public TeacherAssignmentService(ITeacherAssignmentRepository teacherassignmentRepository)
        {
            _teacherassignmentRepository = teacherassignmentRepository;

        }
        public async Task<TeacherAssignment> GetTeacherAssignmentByIdAsync(int teacherId, int classId, int SubjectId)
        {
            try
            {
                var teacherassignment = await _teacherassignmentRepository.GetByIdAsync(teacherId, classId, SubjectId);
                if (teacherassignment == null)
                {
                    return null;
                }
                return teacherassignment;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<TeacherAssignment> AddTeacherAssignmentAsync(TeacherAssignment model)
        {

            await _teacherassignmentRepository.AddAsync(model);
            return model;

        }
        public async Task<bool> UpdateTeacherAssignmentAsync(TeacherAssignment model)
        {
            try
            {
                var teacherassignment = await _teacherassignmentRepository.GetByIdAsync(model.TeacherId, model.ClassId, model.SubjectId);
                if (teacherassignment == null)
                {
                    return false;
                }

                teacherassignment.TeacherId = model.TeacherId;
                teacherassignment.SubjectId = model.SubjectId;
                teacherassignment.ClassId = model.ClassId;

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<bool> DeleteTeacherAssignmentAsync(TeacherAssignment model)
        {
            try
            {
                var teacherassignment = await _teacherassignmentRepository.GetByIdAsync(model);
                if (teacherassignment == null)
                {
                    return false;
                }
                await _teacherassignmentRepository.DeleteAsync(teacherassignment);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}