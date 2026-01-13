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

namespace ProjetoNotas.Data
{
    public class EscolaDataContext : DbContext
    {

        public DbSet<Class> Classs { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<MyTask> MyTasks { get; set; }

        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=Sistema_escolar;Username=postgres;Password=1234");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new ClassMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new SubjectMapping());

            modelBuilder.ApplyConfiguration(new MyTaskMapping());
        }
    }
}