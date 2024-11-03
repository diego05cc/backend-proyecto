using backend_proyecto.model;

namespace backend_proyecto.DTOs
{
    public class DTOTasks
    {
        public int Id { get; set; }
        public  string Nombre { get; set; }
        public  string Descripcion { get; set; }
        public int ProyectoId { get; set; }
        public bool IsDeleted { get; set; }

    }
}