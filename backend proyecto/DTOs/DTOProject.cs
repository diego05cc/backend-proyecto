using System.Threading;
using backend_proyecto.model;

namespace backend_proyecto.DTOs
{
    public class DTOProject
    {
        public int Id { get; set; }
        public  string Nombre { get; set; }
        public  string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public  bool IsDeleted { get; set; }

    }
}
