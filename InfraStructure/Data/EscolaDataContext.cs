using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.InfraStructure.Mapping;
using ProjetoNotas.Mapping;
using ProjetoNotas.Models;

namespace ProjetoNotas.Data
{
     public class EscolaDataContext : DbContext
    {
     public DbSet<Aluno> Alunos { get; set; }

     public DbSet<Classe> Classes { get; set; }

     public DbSet<Administrador> Administradores{ get; set; }

     public DbSet<Professor> Professores{ get; set; }
     public DbSet<Disciplina> Disciplinas{ get; set; }
     public DbSet<Nota> Notas{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
          
            
            options.UseSqlServer(@"Host=mylocalhost;Database=mydatabase;Username=myusername;Password=mypassword");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapping());
            modelBuilder.ApplyConfiguration(new ClasseMapping());
            modelBuilder.ApplyConfiguration(new ProfessorMapping());
            modelBuilder.ApplyConfiguration(new DisciplinaMapping());
            modelBuilder.ApplyConfiguration(new NotaMapping());
        }
    }
}