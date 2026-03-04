using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.Models.Responses
{
    public class SubmittedTaskResponse
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int StudentId { get; set; }

        public int MyTaskId { get; set; }

        public float Score { get; set; }

        public int SubjectId { get; set; }

        public int Unit { get; set; }
    }
}