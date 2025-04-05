using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Models;

namespace ProjetoNotas.Mapping
{
    public class TeacherMapping : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher");
            builder.HasKey(x => x.TeacherId);
            builder.Property(x => x.TeacherId)
            .ValueGeneratedOnAdd().UseIdentityColumn(); ;

            builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("Text")
            .HasColumnName("Name")
            .HasMaxLength(30);

            builder.Property(x => x.Age)
            .IsRequired()
            .HasColumnType("Text")
            .HasColumnName("Age")
            .HasMaxLength(2);

            builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnType("Text")
            .HasColumnName("Email")
            .HasMaxLength(100);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnType("Text")
            .HasColumnName("Password")
            .HasMaxLength(30);
        }
    }
}