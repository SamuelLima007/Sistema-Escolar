using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.InfraStructure.Mapping
{
    public class AdministradorMapping : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnType("Text")
            .HasColumnName("Nome")
            .HasMaxLength(30);

            builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnType("Text")
            .HasColumnName("Email")
            .HasMaxLength(100);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Senha)
            .IsRequired()
            .HasColumnType("NText")
            .HasColumnName("Senha")
            .HasMaxLength(150);

            builder.Property(x => x.Role)
            .IsRequired()
            .HasColumnType("Text")
            .HasColumnName("Roles")
            .HasMaxLength(20);
        }
    }
}