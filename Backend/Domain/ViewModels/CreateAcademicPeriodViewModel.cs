using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.ViewModels
{
    public class CreateAcademicViewModel
    {
           
        public string Year { get; set; }
        public int Unit { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; } = false;
    }
}