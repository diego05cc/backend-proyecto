namespace backend_proyecto.model
{
    public class Employed
    {
        public int Employed_Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Departamento { get; set; }
        public required string Cargo { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime FechaIngreso{ get; set; }
        public List<Employedproject> Employedprojects { get; set; }
        public List<Registeroftime> RegistrosDeTiempo { get; set; }
    }
}

