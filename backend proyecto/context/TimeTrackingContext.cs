using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;

public class TimeTrackingContext : DbContext

{
    public TimeTrackingContext(DbContextOptions<TimeTrackingContext> options): base(options)
       { 
    
        }
     
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Proyecto> Proyectos { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<RegistroDeTiempo> RegistrosDeTiempo { get; set; }
    public DbSet<EmpleadoProyecto> EmpleadoProyectos { get; set; } // Tabla intermedia

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmpleadoProyecto>()
       .HasKey(ep => new { ep.EmpleadoId, ep.ProyectoId }); // Define la clave primaria compuesta

        modelBuilder.Entity<EmpleadoProyecto>()
            .HasOne(ep => ep.Empleado)
            .WithMany(e => e.EmpleadoProyectos)
            .HasForeignKey(ep => ep.EmpleadoId);

        modelBuilder.Entity<EmpleadoProyecto>()
            .HasOne(ep => ep.Proyecto)
            .WithMany(p => p.EmpleadoProyectos)
            .HasForeignKey(ep => ep.ProyectoId);

        modelBuilder.Entity<Tarea>()
            .HasOne(t => t.Proyecto)
            .WithMany(p => p.Tareas)
            .HasForeignKey(t => t.ProyectoId);

        modelBuilder.Entity<RegistroDeTiempo>()
            .HasOne(rt => rt.Empleado)
            .WithMany(e => e.RegistrosDeTiempo)
            .HasForeignKey(rt => rt.EmpleadoId);

        modelBuilder.Entity<RegistroDeTiempo>()
            .HasOne(rt => rt.Tarea)
            .WithMany(t => t.RegistrosDeTiempo)
            .HasForeignKey(rt => rt.TareaId);

    }
}