using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoScores.Domain.Models;

namespace ProjetoScores.InfraStructure.Mapping
{
    public class AdministratorMapping : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("Text")
            .HasColumnName("Name")
            .HasMaxLength(30);

            builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnType("Text")
            .HasColumnName("Email")
            .HasMaxLength(100);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnType("NText")
            .HasColumnName("Password")
            .HasMaxLength(150);

            builder.Property(x => x.Role)
            .IsRequired()
            .HasColumnType("Text")
            .HasColumnName("Roles")
            .HasMaxLength(20);
        }
    }
}