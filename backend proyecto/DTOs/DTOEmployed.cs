using backend_proyecto.model;
namespace backend_proyecto.DTOs
{
    public class DTOEmployed
    {
        public int Employed_Id { get; set; }
        public  string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Departamento { get; set; }
        public string Cargo { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime FechaIngreso{ get; set; } = DateTime.UtcNow;
    }
}

