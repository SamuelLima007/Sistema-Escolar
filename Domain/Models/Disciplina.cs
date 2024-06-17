using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Models;

namespace ProjetoNotas.Domain.Models
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }

        public IList<Aluno> Alunos { get; set; } = new List<Aluno>();
        public IList<Nota> Notas { get; set; } = new List<Nota>();




    }
}