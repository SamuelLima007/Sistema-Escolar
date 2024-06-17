using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.Models
{
    public class Aluno : User
    {
        public int AlunoId { get; set; }
       
        public int Idade { get; set; }
    
        

        public int Classe_Id { get; set; }
        public Classe? Classe { get; set; } 

        public IList<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
       
       public IList<Nota> Notas { get; set; }

       public override string Role => "Aluno";

       

        


        
    }
}