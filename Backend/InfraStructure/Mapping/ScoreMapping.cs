using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.InfraStructure.Mapping
{
    public class ScoreMapping : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("Score");

            builder.HasKey(x => x.ScoreId);

            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnType("decimal(4,2)");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Scores)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.Scores)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
