using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.InfraStructure.Mapping
{
    public class SubjectMapping : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject");

            builder.HasKey(x => x.SubjectId);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
