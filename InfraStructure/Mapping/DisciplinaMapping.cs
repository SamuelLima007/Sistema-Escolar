using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.InfraStructure.Mapping
{
    public class DisciplinaMapping : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.ToTable("Disciplina");
            builder.HasKey(x => x.DisciplinaId);
            builder.Property(x => x.DisciplinaId)
            .ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Nome)
           .IsRequired()
           .HasColumnType("VARCHAR")
           .HasColumnName("Nome")
           .HasMaxLength(30);
            builder.HasIndex(x => x.Nome).IsUnique();
        }
    }
}