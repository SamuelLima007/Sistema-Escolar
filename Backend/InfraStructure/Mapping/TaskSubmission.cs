using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.InfraStructure.Mapping
{
    public class TaskSubmissionMapping : IEntityTypeConfiguration<TaskSubmission>
    {
        public void Configure(EntityTypeBuilder<TaskSubmission> builder)
        {

            builder.ToTable("TaskSubmission");

            builder.HasKey(x => new { x.StudentId, x.MyTaskId });

            builder.HasOne(x => x.Student)
                   .WithMany(x => x.TasksSubmission)
                   .HasForeignKey(x => x.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Task)
                   .WithMany()
                   .HasForeignKey(x => x.MyTaskId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.Property(x => x.Score).IsRequired().HasMaxLength(100);

            builder.HasIndex(x => new { x.StudentId, x.MyTaskId })
                   .IsUnique();
        }
    }
}