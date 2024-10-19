using System.Threading;

namespace backend_proyecto.model
{
    public class Proyecto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public DateTime
 FechaInicio
        { get; set; }
        public DateTime FechaFin { get; set; }
        public required ICollection<EmpleadoProyecto> EmpleadoProyectos
        { get; set; }
        public required ICollection<Tarea> Tareas { get; set; }
    }
}
