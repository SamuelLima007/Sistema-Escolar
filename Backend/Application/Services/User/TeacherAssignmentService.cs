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
        public async Task<bool> UpdateTeacherAssignmentAsync(int teacherId, int classId, int subjectId, CreateTeacherAssignmentViewModel model)
        {
                var teacherassignment = await _teacherassignmentRepository.GetByIdAsync(teacherId, classId, subjectId);
                if (teacherassignment == null)
                {
                    return false;
                }
                 var newteacherassignment = new TeacherAssignment
                 {
                    TeacherId = teacherassignment.TeacherId,
                     ClassId = teacherassignment.ClassId,
                     SubjectId = teacherassignment.SubjectId
                 };
                 newteacherassignment.TeacherId = model.TeacherId ?? teacherId;
                newteacherassignment.SubjectId = model.SubjectId ?? subjectId;
                newteacherassignment.ClassId = model.ClassId ?? classId;
                 await _teacherassignmentRepository.DeleteAsync(teacherassignment);
         
            
                await _teacherassignmentRepository.AddAsync(newteacherassignment);

                return true;
           
        }
        public async Task<bool> DeleteTeacherAssignmentAsync(int teacherId, int classId, int subjectId)
        {
            try
            {
                var teacherassignment = await _teacherassignmentRepository.GetByIdAsync(teacherId,  classId,  subjectId);
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