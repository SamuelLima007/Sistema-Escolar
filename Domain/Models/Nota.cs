using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Models;

namespace ProjetoNotas.Domain.Models
{
    public class Nota
    {

        public int NotaId { get; set; }

        public double Valor { get; set; }

        public int Disciplina_Id { get; set; }

        public Disciplina Disciplina { get; set; }

        public Aluno Aluno { get; set; }

        public int Aluno_Id { get; set; }
    

        

    }
}