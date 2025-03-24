using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoScores.Domain.Models;

namespace ProjetoScores.InfraStructure.Mapping
{
    public class ScoreMapping : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("Score");
            builder.HasKey(x => x.ScoreId);
            builder.Property(x => x.ScoreId)
            .ValueGeneratedOnAdd().UseIdentityColumn(); ;

            builder.Property(x => x.Value)
            .IsRequired()
            .HasColumnType("decimal(2, 2)")
            .HasColumnName("Value")
            .HasMaxLength(4);

            builder.HasOne(x => x.Subject)
            .WithMany(x => x.Scores)
            .HasConstraintName("FK_NOTA")
            .HasForeignKey(x => x.Subject_Id)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Student)
            .WithMany(x => x.Scores)
            .HasForeignKey(n => n.Student_Id);

            builder.HasOne(x => x.Subject)
             .WithMany(x => x.Scores)
            .HasForeignKey(x => x.Subject_Id);
        }
    }
}