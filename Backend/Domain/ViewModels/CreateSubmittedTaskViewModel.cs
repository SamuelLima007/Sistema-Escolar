using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.ViewModels
{
    public class CreateSubmittedTaskViewModel
    {
        public int StudentId { get; set; }
        public int MyTaskId { get; set; }
        public int Score { get; set; }
    }
}