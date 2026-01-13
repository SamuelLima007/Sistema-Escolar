using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class TaskSubmission
    {
        public int UserId { get; set; }
    
        public int MyTaskId { get; set; }
        
        public decimal Score { get; set; } 
    }
}