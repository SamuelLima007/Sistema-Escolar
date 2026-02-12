using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Domain.Models;

namespace Backend.InfraStructure.Mapping
{
    public class ClassSubjectMapping : IEntityTypeConfiguration<ClassSubject>
    {
         public void Configure(EntityTypeBuilder<ClassSubject> builder)
        {

            builder.ToTable("ClassSubject");

            builder.HasKey(x => new { x.ClassId, x.SubjectId });

            builder.HasOne(x => x.Class)
                   .WithMany()
                   .HasForeignKey(x => x.ClassId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Subject)
                   .WithMany()
                   .HasForeignKey(x => x.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);


      

            builder.HasIndex(x => new { x.ClassId, x.SubjectId })
                   .IsUnique();
        }

        public void Configure(EntityTypeBuilder<Class> builder)
        {
            throw new NotImplementedException();
        }

   
    }
}