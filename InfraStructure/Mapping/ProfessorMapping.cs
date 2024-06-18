using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Models;

namespace ProjetoNotas.Mapping
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");
            builder.HasKey(x => x.ProfessorId);
            builder.Property(x => x.ProfessorId)
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
            .HasColumnType("VARCHAR")
            .HasColumnName("Senha")
            .HasMaxLength(30);
        }
    }
}