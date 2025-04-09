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
    public class ClassMapping : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Class");
            builder.HasKey(x => x.ClassId);
            builder.Property(x => x.ClassId)
            .ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Grade)
            .IsRequired()
            .HasColumnType("Text")
            .HasColumnName("Grade")
            .HasMaxLength(30);

            builder.Property(x => x.Section)
            .IsRequired()
            .HasColumnType("Text")
            .HasColumnName("Section")
            .HasMaxLength(2);

            builder.HasMany(x => x.Teacheres)
            .WithMany(x => x.Classs)
            .UsingEntity<Dictionary<string, object>>(

             "ClassTeacher",

              Teacher => Teacher.HasOne<Teacher>()
             .WithMany()
             .HasForeignKey("TeacherId")
             .HasConstraintName("FK_ClassTeacher_TeacherId")
             .OnDelete(DeleteBehavior.NoAction),

             Class => Class.HasOne<Class>()
             .WithMany()
             .HasForeignKey("ClassId")
             .HasConstraintName("FK_ClassTeacher_ClassId")
             .OnDelete(DeleteBehavior.NoAction));
        }
    }
}