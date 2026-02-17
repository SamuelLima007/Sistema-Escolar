using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace Backend.Domain.Models.Responses
{
    public class ClassResponse
    {
          public int Id { get; set; }
        public string Grade { get; set; }

        public ICollection<MyTaskResponse> MyTasks { get; set; } = new List<MyTaskResponse>();

         public Subject[]? Subjects { get; set; }


         public void ConvertTasks(ICollection<MyTask> tasks)
        {
            foreach (var task in tasks)
            {
                var newtask = new MyTaskResponse
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    CreationDate = task.CreationDate,
                    ExpirationDate = task.ExpirationDate,
                    ClassId = task.ClassId,
                    SubjectName = task.Subject.Name,
                    SubjectId = task.SubjectId,
                    TeacherId = task.TeacherId,
                    Score = task.score,
                    
                    
                };
                MyTasks.Add(newtask);
            }
            
        }
    }

    
}