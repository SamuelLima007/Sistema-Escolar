using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoNotas.Domain.Models;

namespace ProjetoNotas.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.FotoPerfil).HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Role).IsRequired().HasMaxLength(20).HasConversion<string>();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.Classes)
               .WithMany(x => x.Users)
               .UsingEntity<Dictionary<string, object>>(
                   "TeacherClass",
                   s => s.HasOne<Class>().WithMany().HasForeignKey("ClassId"),
                   u => u.HasOne<User>().WithMany().HasForeignKey("UserId")
               );

            builder.HasMany(x => x.Subjects)
                .WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserSubject",
                    s => s.HasOne<Subject>().WithMany().HasForeignKey("SubjectId"),
                    u => u.HasOne<User>().WithMany().HasForeignKey("UserId")
                );
        }
    }
}
