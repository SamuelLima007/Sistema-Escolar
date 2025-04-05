using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.InfraStructure.Mapping
{
    public class SubjectMapping : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject");
            builder.HasKey(x => x.SubjectId);
            builder.Property(x => x.SubjectId)
            .ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Name)
           .IsRequired()
           .HasColumnType("Text")
           .HasColumnName("Name")
           .HasMaxLength(30);
            builder.HasIndex(x => x.Name).IsUnique();
            
        }
    }
}