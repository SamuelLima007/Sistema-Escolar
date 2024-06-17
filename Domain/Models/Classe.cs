using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.Models
{
    public class Classe
    {
        public int ClasseId { get; set; }
        public string? Serie { get; set; }
        public string? Turma { get; set; }

        public IList<Professor> Professores { get; set; } = new List<Professor>();

        public IList<Aluno> Alunos { get; set; } = new List<Aluno>();

        public IList<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        
    }
}