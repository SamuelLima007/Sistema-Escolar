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
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");
            builder.HasKey(x => x.AlunoId);
            builder.Property(x => x.AlunoId)
            .ValueGeneratedOnAdd().UseIdentityColumn(); ;

            builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName("Nome")
            .HasMaxLength(30);

            builder.Property(x => x.Idade)
            .IsRequired()
            .HasColumnType("INT")
            .HasColumnName("Idade")
            .HasMaxLength(2);

            builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName("Email")
            .HasMaxLength(100);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Senha)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasColumnName("Senha")
            .HasMaxLength(150);

            builder.Property(x => x.Role)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName("Roles")
            .HasMaxLength(20);

            builder.HasOne(x => x.Classe)
            .WithMany(x => x.Alunos)
            .HasConstraintName("FK_ALUNO")
            .HasForeignKey(x => x.Classe_Id)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Disciplinas)
            .WithMany(x => x.Alunos)
            .UsingEntity<Dictionary<string, object>>(

             "AlunoDisciplina",

              Disciplina => Disciplina.HasOne<Disciplina>()
             .WithMany()
             .HasForeignKey("DisciplinaId")
             .HasConstraintName("FK_AlunoDisciplina_DisciplinaId")
             .OnDelete(DeleteBehavior.NoAction),

             Aluno => Aluno.HasOne<Aluno>()
             .WithMany()
             .HasForeignKey("AlunoId")
             .HasConstraintName("FK_AlunoDisciplina_AlunoId")
             .OnDelete(DeleteBehavior.NoAction));
        }
    }
}