using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Models;

namespace ProjetoNotas.Mapping
{
    public class ClasseMapping : IEntityTypeConfiguration<Classe>
    {


        public void Configure(EntityTypeBuilder<Classe> builder)
        {
            builder.ToTable("Classe");

            builder.HasKey(x => x.ClasseId);

            builder.Property(x => x.ClasseId)
            .ValueGeneratedOnAdd().UseIdentityColumn();


            builder.Property(x => x.Serie)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName("Serie")
            .HasMaxLength(30);

            builder.Property(x => x.Turma)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName("Turma")
            .HasMaxLength(2);

            builder.HasMany(x => x.Professores)
            .WithMany(x => x.Classes)
            .UsingEntity<Dictionary<string, object>>(


             "ClasseProfessor",

              Professor => Professor.HasOne<Professor>()
             .WithMany()
             .HasForeignKey("ProfessorId")
             .HasConstraintName("FK_ClasseProfessor_ProfessorId")
             .OnDelete(DeleteBehavior.NoAction),

             Classe => Classe.HasOne<Classe>()
             .WithMany()
             .HasForeignKey("ClasseId")
             .HasConstraintName("FK_ClasseProfessor_ClasseId")
             .OnDelete(DeleteBehavior.NoAction));

           
             


             

            

        }
    }
}