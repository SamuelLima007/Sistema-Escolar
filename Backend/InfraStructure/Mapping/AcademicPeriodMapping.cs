using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Domain.Models;

namespace Backend.InfraStructure.Mapping
{
    public class AcademicPeriodMapping : IEntityTypeConfiguration<AcademicPeriod>
    {
        public void Configure(EntityTypeBuilder<AcademicPeriod> builder)
        {
            builder.ToTable("AcademicPeriods");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Unit).IsRequired();
            builder.Property(x => x.StartDate) .IsRequired().HasConversion<string>();;
            builder.Property(x => x.EndDate).IsRequired().HasConversion<string>();;
            builder.Property(x => x.Active) .IsRequired();
            builder.HasIndex(x => new { x.Year, x.Unit }).IsUnique();  
            
        }
    }
}