using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces.Repositoryes.Users;
using Backend.Domain.Interfaces.Services.Users;
using Backend.Domain.Models;
using Backend.Domain.ViewModels;
using ProjetoNotas.Domain.Models;

namespace Backend.Application.Services.School
{
    public class TeacherAssignmentService : ITeacherAssignmentService
    {
        private readonly ITeacherAssignmentRepository _teacherassignmentRepository;
        public TeacherAssignmentService(ITeacherAssignmentRepository teacherassignmentRepository)
        {
            _teacherassignmentRepository = teacherassignmentRepository;

        }
        public async Task<ApiResponse<TeacherAssignment>> GetTeacherAssignmentByIdAsync(int teacherId, int classId, int subjectId)
        {
            try
            {
                var teacherassignment = await _teacherassignmentRepository.GetByIdAsync(teacherId, classId, subjectId);
                if (teacherassignment == null)
                {
                    return ResponseApiExtension<TeacherAssignment>.CreateApiResponseFail(new ApiResponse<TeacherAssignment>("Assignment não encontrado"));
                }
                return ResponseApiExtension<TeacherAssignment>.CreateApiResponseSucess(new ApiResponse<TeacherAssignment>("Assignment encontrado", teacherassignment));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<TeacherAssignment>> AddTeacherAssignmentAsync(TeacherAssignment model)
        {
            try
            {
                if (model == null)
                {
                    return ResponseApiExtension<TeacherAssignment>.CreateApiResponseFail(new ApiResponse<TeacherAssignment>("Verifique o formato do JSON", new TeacherAssignment() { }));
                }

                if (await _teacherassignmentRepository.GetByIdAsync(model.TeacherId, model.ClassId, model.SubjectId) != null)
                {
                    return ResponseApiExtension<TeacherAssignment>.CreateApiResponseFail(new ApiResponse<TeacherAssignment>("Já existe um assignment com esses Ids", new TeacherAssignment() { })); ;
                }

                await _teacherassignmentRepository.AddAsync(model);
                return ResponseApiExtension<TeacherAssignment>.CreateApiResponseSucess(new ApiResponse<TeacherAssignment>("Assignment adicionado com sucesso", model)); ;
            }

            catch
            {
                throw new Exception("Falha interna no servidor");
            }

        }
        public async Task<ApiResponse<TeacherAssignment>> UpdateTeacherAssignmentAsync(int teacherId, int classId, int subjectId, CreateTeacherAssignmentViewModel model)
        {

            if (model == null)
            {
                return ResponseApiExtension<TeacherAssignment>.CreateApiResponseFail(new ApiResponse<TeacherAssignment>("Verifique o formato do JSON", new TeacherAssignment() { }));
            }

            model.TeacherId ??= teacherId;
            model.ClassId ??= classId;
            model.SubjectId ??= subjectId;

            var existingAssignment = await _teacherassignmentRepository.GetByIdAsync((int)model.TeacherId, (int)model.ClassId, (int)model.SubjectId); 
            if (existingAssignment != null)
            {
                return ResponseApiExtension<TeacherAssignment>.CreateApiResponseFail(new ApiResponse<TeacherAssignment>("Já existe um assignment com esses Ids", existingAssignment)); ;
            }

            var teacherassignment = await _teacherassignmentRepository.GetByIdAsync(teacherId, classId, subjectId);
            if (teacherassignment == null)
            {
                return ResponseApiExtension<TeacherAssignment>.CreateApiResponseFail(new ApiResponse<TeacherAssignment>("Assignment não encontrado", new TeacherAssignment() { })); ;
            }

            var newteacherassignment = new TeacherAssignment
            {
                TeacherId = (int)model.TeacherId,
                ClassId = (int)model.ClassId,
                SubjectId = (int)model.SubjectId
            };

            await _teacherassignmentRepository.DeleteAsync(teacherassignment);
            await _teacherassignmentRepository.AddAsync(newteacherassignment);

            return ResponseApiExtension<TeacherAssignment>.CreateApiResponseFail(new ApiResponse<TeacherAssignment>("Assignment não encontrado", newteacherassignment)); ;
        }
        public async Task<ApiResponse<TeacherAssignment>> DeleteTeacherAssignmentAsync(int teacherId, int classId, int subjectId)
        {
            try
            {
                var teacherassignment = await _teacherassignmentRepository.GetByIdAsync(teacherId, classId, subjectId);
                if (teacherassignment == null)
                {
                    return ResponseApiExtension<TeacherAssignment>.CreateApiResponseFail(new ApiResponse<TeacherAssignment>("Assignment inexistente"));
                }
                await _teacherassignmentRepository.DeleteAsync(teacherassignment);
                return ResponseApiExtension<TeacherAssignment>.CreateApiResponseSucess(new ApiResponse<TeacherAssignment>("Usuario deletado com sucesso", teacherassignment));
            }

            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
    }
}