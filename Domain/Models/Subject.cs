using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoScores.Models;

namespace ProjetoScores.Domain.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public IList<Student> Students { get; set; } = new List<Student>();
        public IList<Score> Scores { get; set; } = new List<Score>();
    }
}