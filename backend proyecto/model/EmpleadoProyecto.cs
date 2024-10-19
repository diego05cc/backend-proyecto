namespace backend_proyecto.model
{
    public class EmpleadoProyecto
    {
        public int EmpleadoId { get; set; }
        public int ProyectoId { get; set; }
        public required Empleado Empleado { get; set; }
        public required Proyecto Proyecto { get; set; }
    }
}