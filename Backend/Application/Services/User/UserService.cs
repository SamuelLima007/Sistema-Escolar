using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Extensions;
using Backend.Domain.Interfaces.Repositoryes.Users;
using Backend.Domain.Models;
using Backend.Domain.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Repository;
using ProjetoNotas.ViewModels;
using SecureIdentity.Password;
namespace ProjetoNotas.WebUi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClassRepository _classRepository;

         private readonly ITeacherAssignmentRepository _teacherassignmentRepository;

         private readonly ISubjectRepository _subjectRepository;



        public UserService(IUserRepository userRepository, IClassRepository classRepository, ITeacherAssignmentRepository teacherassignmentRepository, ISubjectRepository subjectRepository)
        {
            _userRepository = userRepository;
            _classRepository = classRepository;
            _teacherassignmentRepository = teacherassignmentRepository;
            _subjectRepository = subjectRepository;

        }

        public async Task<ApiResponse<UserResponse>> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    return ResponseApiExtension<UserResponse>.CreateApiResponseFail(new ApiResponse<UserResponse>("Usuario inexistente"));
               
                }

            
                var UserResponse = new UserResponse
                {
                    Name = user.Name,
                    Id = user.Id,
                    Role = user.Role,
                 
                };
              
                return ResponseApiExtension<UserResponse>.CreateApiResponseSucess(new ApiResponse<UserResponse>("Usuario encontrado", UserResponse));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }

        }

        public async Task<ApiResponse<UserResponse>> GetStudentByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.CompleteUser(id);
                if (user == null)
                {
                    return ResponseApiExtension<UserResponse>.CreateApiResponseFail(new ApiResponse<UserResponse>("Usuario inexistente"));
                }
                var IDS = await _teacherassignmentRepository.GetByClassIdAsync((int)user.ClassId);
                user.Subjects =  await _subjectRepository.GetByClassIdAsync(IDS.Select(x => x.SubjectId).ToList());


                var classresponse = new ClassResponse
                {
                    Id = (int)user.ClassId,
                    Grade = user.Class.Grade,
                    Subjects = user.Subjects.ToArray()
                };
                classresponse.ConvertTasks(user.Class.MyTasks);
            
                var UserResponse = new StudentResponse
                {
                    Name = user.Name,
                    Id = user.Id,
                    Role = user.Role,
                    Class = classresponse,
                   
                };
                UserResponse.ConvertSubmittedTasks(user.SubmittedTasks.ToArray());
             
                return ResponseApiExtension<UserResponse>.CreateApiResponseSucess(new ApiResponse<UserResponse>("Usuario encontrado", UserResponse));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<ApiResponse<User>> AddUserAsync(CreateUserViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return ResponseApiExtension<User>.CreateApiResponseFail(new ApiResponse<User>("Verifique o formato do JSON", new User() { }));
                }

                var user = new User()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = PasswordHasher.Hash(model.Password),
                    Role = model.Role,
                    ClassId = model.ClassId
                };

                await _userRepository.AddAsync(user);
                return ResponseApiExtension<User>.CreateApiResponseSucess(new ApiResponse<User>("Usuario adicionado com sucesso", user));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<User>> UpdateUserAsync(int id, CreateUserViewModel model)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (model == null)
                {
                    return ResponseApiExtension<User>.CreateApiResponseFail(new ApiResponse<User>("Verifique o formato do JSON", new User() { }));
                }

                if (user == null)
                {
                    return ResponseApiExtension<User>.CreateApiResponseFail(new ApiResponse<User>("Usuario não encontrado"));
                }
                if (model.Password != null) model.Password = PasswordHasher.Hash(model.Password);
                user.Update(model.Name, model.Email, model.Password);

                await _userRepository.UpdateAsync(user);
                return ResponseApiExtension<User>.CreateApiResponseSucess(new ApiResponse<User>("Usuario atualizado com sucesso", user)); ;
            }

            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }
        }
        public async Task<ApiResponse<User>> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    return ResponseApiExtension<User>.CreateApiResponseFail(new ApiResponse<User>("Usuario inexistente"));
                }
                await _userRepository.DeleteAsync(user);
                return ResponseApiExtension<User>.CreateApiResponseSucess(new ApiResponse<User>("Usuario deletado com sucesso", user));
            }
            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }

        }

        public async Task<ApiResponse<UserResponse>> GetTeacherByClassAndSubject(int subjectId, int classId)
        {
            try
            {
                var assignment = await _teacherassignmentRepository.GetBySubjectAndClassIdAsync(subjectId, classId);
                var user = await _userRepository.GetByIdAsync(assignment.TeacherId);
                if (user == null)
                {
                    return ResponseApiExtension<UserResponse>.CreateApiResponseFail(new ApiResponse<UserResponse>("Usuario inexistente"));
                }
                var teacher = new TeacherResponse()
                {
                    Name = user.Name,
                    email = user.Email,
                    Role = user.Role,
                  
                };

                return ResponseApiExtension<UserResponse>.CreateApiResponseSucess(new ApiResponse<UserResponse>("Usuario encontrado com sucesso", teacher));
            }

            catch (Exception)
            {
                throw new Exception("Falha interna no servidor");
            }

        }

        
    }
}