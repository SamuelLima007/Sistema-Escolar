using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.Models.Responses
{
    public class StudentResponse : UserResponse
    {
        


        public ClassResponse Class { get; set; }

         
        public ICollection<SubmittedTaskResponse?> SubmittedTasks { get; set; } =  new List<SubmittedTaskResponse>();

        public void ConvertSubmittedTasks(ICollection<SubmittedTask> tasks)
        {
            foreach (var task in tasks)
            {
                if (Class.MyTasks.Any(x => x.Id == task.MyTaskId))
                {
                    var classtask = Class.MyTasks.FirstOrDefault(x => x.Id == task.MyTaskId);
                 
                    var submittedtask = new SubmittedTaskResponse
                    {
                        MyTaskId = task.MyTaskId,
                        Score = task.Score,
                        StudentId = task.StudentId,
                        Description = classtask.Description,
                        Name = classtask.Name,
                        SubjectId = classtask.SubjectId,
                        Unit = classtask.Unit
                    };
                    SubmittedTasks.Add(submittedtask);
                }

            }

        }
    }
}