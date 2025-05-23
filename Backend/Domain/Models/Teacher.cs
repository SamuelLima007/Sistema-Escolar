using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.Models
{
    public class Teacher : User
    {
        public int TeacherId { get; set; }
        public int Age { get; set; }
        public override string Role => "Teacher";
        public IList<Class> Classs { get; set; } = new List<Class>();
    }
}