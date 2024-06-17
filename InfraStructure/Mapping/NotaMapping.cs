using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.InfraStructure.Mapping
{
    public class NotaMapping : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.ToTable("Nota");

            builder.HasKey(x => x.NotaId);

            builder.Property(x => x.NotaId)
            .ValueGeneratedOnAdd().UseIdentityColumn(); ;


            builder.Property(x => x.Valor)
            .IsRequired()
            .HasColumnType("decimal(2, 2)")
            .HasColumnName("Valor")
            .HasMaxLength(4);

            builder.HasOne(x => x.Disciplina)
            .WithMany(x => x.Notas)
            .HasConstraintName("FK_NOTA")
            .HasForeignKey(x => x.Disciplina_Id)
            .OnDelete(DeleteBehavior.NoAction);

      

            builder
               .HasOne(x => x.Aluno)
               .WithMany(x => x.Notas)
               .HasForeignKey(n => n.Aluno_Id);

            builder
               .HasOne(x => x.Disciplina)
               .WithMany(x => x.Notas)
               .HasForeignKey(x => x.Disciplina_Id);
        }
    }
}