using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.InfraStructure.Mapping
{
    public class SubmittedTaskMapping : IEntityTypeConfiguration<SubmittedTask>
    {
        public void Configure(EntityTypeBuilder<SubmittedTask> builder)
        {

            builder.ToTable("SubmittedTask");

            builder.HasKey(x => new { x.StudentId, x.MyTaskId });

            builder.HasOne(x => x.Student)
                   .WithMany(x => x.SubmittedTasks)
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