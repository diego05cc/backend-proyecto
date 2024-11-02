using System.Threading;

namespace backend_proyecto.model
{
    public class Project
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public List<Employedproject> Employedprojects{ get; set; }

        public List<Tasks> Tasks { get; set; }

        public virtual required bool IsDeleted { get; set; }

    }
}
