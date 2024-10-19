namespace backend_proyecto.model
{
    public class Empleado
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Departamento { get; set; }
        public required string Cargo { get; set; }
        public
 DateTime FechaIngreso
        { get; set; }
        public required ICollection<EmpleadoProyecto> EmpleadoProyectos { get; set; }
        public required ICollection<RegistroDeTiempo> RegistrosDeTiempo { get; set; }
    }
}

