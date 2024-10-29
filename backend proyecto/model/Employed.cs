namespace backend_proyecto.model
{
    public class Employed
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Departamento { get; set; }
        public required string Cargo { get; set; }
        public bool IsDeleted { get; set; }

        public
 DateTime FechaIngreso
        { get; set; }
        public required ICollection<Employedproject> EmpleadoProyectos { get; set; }
        public required ICollection<Registeroftime> RegistrosDeTiempo { get; set; }
    }
}

