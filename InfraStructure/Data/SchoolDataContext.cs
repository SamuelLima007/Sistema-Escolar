using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoScores.Domain.Models;
using ProjetoScores.InfraStructure.Mapping;
using ProjetoScores.Mapping;
using ProjetoScores.Models;
namespace ProjetoScores.Data
{
    public class EscolaDataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classs { get; set; }
        public DbSet<Administrator> Administratores { get; set; }
        public DbSet<Teacher> Teacheres { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Score> Scores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=banquinho");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMapping());
            modelBuilder.ApplyConfiguration(new ClassMapping());
            modelBuilder.ApplyConfiguration(new TeacherMapping());
            modelBuilder.ApplyConfiguration(new SubjectMapping());
            modelBuilder.ApplyConfiguration(new ScoreMapping());
        }
    }
}