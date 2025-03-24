using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoScores.Models;

namespace ProjetoScores.Domain.Models
{
    public class Score
    {
        public int ScoreId { get; set; }
        public double Value { get; set; }
        
        public int Subject_Id { get; set; }
        public Subject Subject { get; set; }
        public Student Student { get; set; }
        public int Student_Id { get; set; }
    }
}