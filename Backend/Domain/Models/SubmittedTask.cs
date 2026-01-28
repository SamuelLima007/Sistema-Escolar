using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace Backend.Domain.Models
{
    public class SubmittedTask
    {

        public int StudentId { get; set; }
        public User Student { get; set; }


        public int MyTaskId { get; set; }
        public MyTask Task { get; set; }

        public decimal Score { get; set; }
    }
}