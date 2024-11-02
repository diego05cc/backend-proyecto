namespace backend_proyecto.model
{
    public class Employedproject
    {
        public int EmpleadoId { get; set; }
        public int ProyectoId { get; set; }

        public required bool IsDeleted { get; set; }
        public required Employed Empleado { get; set; }
        public required Project Proyecto { get; set; }
    }
}