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
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(x => x.StudentId);
            builder.Property(x => x.StudentId)
            .ValueGeneratedOnAdd().UseIdentityColumn(); ;

            builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("Text")
            .HasColumnName("Name")
            .HasMaxLength(30);

            builder.Property(x => x.Age)
            .IsRequired()
            .HasColumnType("INT")
            .HasColumnName("Age")
            .HasMaxLength(2);

            builder.Property(a => a.FotoPerfil)
            .HasColumnType("Text")
            .HasColumnName("FotoPerfil")
            .HasMaxLength(255);
    
        
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

            builder.HasOne(x => x.Class)
            .WithMany(x => x.Students)
            .HasConstraintName("FK_ALUNO")
            .HasForeignKey(x => x.Class_Id)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Subjects)
            .WithMany(x => x.Students)
            .UsingEntity<Dictionary<string, object>>(

             "StudentSubject",

              Subject => Subject.HasOne<Subject>()
             .WithMany()
             .HasForeignKey("SubjectId")
             .HasConstraintName("FK_StudentSubject_SubjectId")
             .OnDelete(DeleteBehavior.NoAction),

             Student => Student.HasOne<Student>()
             .WithMany()
             .HasForeignKey("StudentId")
             .HasConstraintName("FK_StudentSubject_StudentId")
             .OnDelete(DeleteBehavior.NoAction));
        }
    }
}