using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.InfraStructure.Mapping
{
    public class MyTaskMapping : IEntityTypeConfiguration<MyTask>
    {
        public void Configure(EntityTypeBuilder<MyTask> builder)
        {
            builder.ToTable("Task");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.DueDate).IsRequired().HasConversion<string>();

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.MyTasks)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Class)
                .WithMany(x => x.MyTasks)
                .HasForeignKey(x => x.ClassId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
