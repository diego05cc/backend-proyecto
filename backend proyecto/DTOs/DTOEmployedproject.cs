using backend_proyecto.model;

namespace backend_proyecto.DTOs
{
    public class DTOEmployedproject
    {
        public int Id { get; set; }
        public required int EmpleadoId { get; set; }
        public required int ProyectoId { get; set; }

        public required bool IsDeleted { get; set; }

    }
}