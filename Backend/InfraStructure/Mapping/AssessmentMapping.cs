using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Domain.Models;

namespace Backend.InfraStructure.Mapping
{
    public class AssessmentMapping : IEntityTypeConfiguration<Assessment>
    {
           public void Configure(EntityTypeBuilder<Assessment> builder)
        {
            builder.ToTable("Assessments");

            
            builder.HasKey(a => a.Id);

           
            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Weight)
                   .IsRequired()
                   .HasColumnType("decimal(5,2)"); 
        }
    }
}  