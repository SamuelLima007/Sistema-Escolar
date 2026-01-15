using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.InfraStructure.Mapping
{
     public class TeacherAssignmentMapping : IEntityTypeConfiguration<TeacherAssignment>
    {
        public void Configure(EntityTypeBuilder<TeacherAssignment> builder)
        {
          
            builder.ToTable("TeacherAssignments");

            builder.HasKey(x => new { x.TeacherId, x.ClassId, x.SubjectId });

            builder.HasOne(x => x.Teacher)
                   .WithMany()
                   .HasForeignKey(x => x.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Class)
                   .WithMany()
                   .HasForeignKey(x => x.ClassId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Subject)
                   .WithMany()
                   .HasForeignKey(x => x.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.TeacherId, x.ClassId, x.SubjectId })
                   .IsUnique();
        }
    }
}