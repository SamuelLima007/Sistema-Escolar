using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoScores.Domain.Models;

namespace ProjetoScores.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string? Grade { get; set; }
        public string? Section { get; set; }
        public IList<Teacher> Teacheres { get; set; } = new List<Teacher>();
        public IList<Student> Students { get; set; } = new List<Student>();
        public IList<Subject> Subjects { get; set; } = new List<Subject>();
    }
}