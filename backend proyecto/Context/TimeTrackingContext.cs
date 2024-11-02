using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace backend_proyecto.Context
{
    public class TimeTrackingContext : DbContext

    {
        public TimeTrackingContext(DbContextOptions<TimeTrackingContext> options) : base(options)
        {

        }

        public DbSet<Employed> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Registeroftime> Registeroftimes { get; set; }
        public DbSet<Employedproject> EmployedProjects { get; set; } // Tabla intermedia

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Employed
            modelBuilder.Entity<Employed>().HasKey(e => e.Employed_Id);
            //EmployedProject
            modelBuilder.Entity<Employedproject>().HasKey(ep => ep.Id); // Define la clave primaria compuesta
            modelBuilder.Entity<Employedproject>().HasOne(ep => ep.Employed).WithMany(e => e.Employedprojects).HasForeignKey(ep => ep.EmpleadoId);
            modelBuilder.Entity<Employedproject>().HasOne(ep => ep.Project).WithMany(p => p.Employedprojects).HasForeignKey(ep => ep.ProyectoId);
            //Project
            modelBuilder.Entity<Project>().HasKey(p => p.Id);
            //Task
            modelBuilder.Entity<Tasks>().HasKey(t => t.Id);
            modelBuilder.Entity<Tasks>().HasOne(t => t.Project).WithMany(p => p.Tasks) .HasForeignKey(t => t.ProyectoId);
            //Registeroftime
            modelBuilder.Entity<Registeroftime>().HasKey(rt => rt.Id);
            modelBuilder.Entity<Registeroftime>().HasOne(rt => rt.Employed).WithMany(e => e.RegistrosDeTiempo).HasForeignKey(rt => rt.EmpleadoId);
            modelBuilder.Entity<Registeroftime>().HasOne(rt => rt.Tasks).WithMany(t => t.Registeroftimes).HasForeignKey(rt => rt.TareaId);

        }
    }
}