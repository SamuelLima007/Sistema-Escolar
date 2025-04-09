using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Enums;
using ProjetoNotas.Models;

namespace ProjetoNotas.ViewModels
{
    public class CreateStudentViewModel
    {
    
        public string? Name { get; set; }
      
        public int Age { get; set; }
      
        public string? Email { get; set; }
       
        public string? Password { get; set; }
        public Class? Class { get; set; }
        public string? Roles { get; set; } = "Student";

        public UserType UserType { get; set; } = UserType.Student;
    }
}



