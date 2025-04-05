using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.Models
{
    public class Student : User
    {
        public int StudentId { get; set; }

        

        [MaxLength(2, ErrorMessage = "Apenas 2 caracteres")]
        public int Age { get; set; }
        public int Class_Id { get; set; }
        public Class? Class { get; set; }
        public IList<Subject> Subjects { get; set; } = new List<Subject>();
        public IList<Score> Scores { get; set; }
        public override string Role => "Student";
    }
}