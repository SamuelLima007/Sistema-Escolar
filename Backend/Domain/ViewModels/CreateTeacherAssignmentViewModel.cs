using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace Backend.Domain.ViewModels
{
    public class CreateTeacherAssignmentViewModel
    {
        public int? TeacherId { get; set; }
      

        public int? ClassId { get; set; }
       

        public int? SubjectId { get; set; }
    }
}