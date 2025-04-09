using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Domain.Models;


namespace ProjetoNotas.InfraStructure.Mapping
{
    public class MyTaskMapping : IEntityTypeConfiguration<MyTask>
    {
        public void Configure(EntityTypeBuilder<MyTask> builder)
        {
            builder.ToTable("Task");

            builder.HasKey(x => x.MyTaskId);
            builder.Property(x => x.MyTaskId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.DueDate)
                .IsRequired();

         builder.HasOne(x => x.Subject)
            .WithMany(x => x.MyTasks)
            .HasForeignKey(x => x.Subject_Id);

              builder.HasOne(x => x.Class)
            .WithMany(x => x.MyTasks)
            .HasForeignKey(n => n.Class_Id);

            
            builder.HasOne(x => x.Class)
                .WithMany(x => x.MyTasks)
                .HasForeignKey(x => x.Class_Id);
        }
    }
 
}