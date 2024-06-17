using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.Models
{
    public class Professor : User
    {
        public int ProfessorId { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }

        public override string Role => "Professor";

        public IList<Classe> Classes { get; set; } = new List<Classe>();

     
    }
}