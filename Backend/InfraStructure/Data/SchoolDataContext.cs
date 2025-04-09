using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.InfraStructure.Mapping;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.InfraStructure.Mapping;
using ProjetoNotas.Mapping;
using ProjetoNotas.Models;
namespace ProjetoNotas.Data
{
    public class EscolaDataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classs { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<MyTask> MyTasks { get; set; }
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
            modelBuilder.ApplyConfiguration(new MyTaskMapping());
        }
    }
}