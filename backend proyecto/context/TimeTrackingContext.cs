using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;

public class TimeTrackingContext : DbContext

{
    public TimeTrackingContext(DbContextOptions<TimeTrackingContext> options) : base(options)
    {

    }

    public DbSet<Employed> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<backend_proyecto.model.Tasks> tasks { get; set; }
    public DbSet<Registeroftime> Registeroftimes { get; set; }
    public DbSet<Employedproject> Employedprojects { get; set; } // Tabla intermedia

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employedproject>()
       .HasKey(ep => new { ep.EmpleadoId, ep.ProyectoId }); // Define la clave primaria compuesta

        modelBuilder.Entity<Employedproject>()
            .HasOne(ep => ep.Empleado)
            .WithMany(e => e.EmpleadoProyectos)
            .HasForeignKey(ep => ep.EmpleadoId);

        modelBuilder.Entity<Employedproject>()
            .HasOne(ep => ep.Proyecto)
            .WithMany(p => p.EmpleadoProyectos)
            .HasForeignKey(ep => ep.ProyectoId);

        modelBuilder.Entity<Tasks>()
            .HasOne(t => t.Proyecto)
            .WithMany(p => p.Tareas)
            .HasForeignKey(t => t.ProyectoId);

        modelBuilder.Entity<Registeroftime>()
            .HasOne(rt => rt.Empleado)
            .WithMany(e => e.RegistrosDeTiempo)
            .HasForeignKey(rt => rt.EmpleadoId);

        modelBuilder.Entity<Registeroftime>()
            .HasOne(rt => rt.Tarea)
            .WithMany(t => t.RegistrosDeTiempo)
            .HasForeignKey(rt => rt.TareaId);

    }
}