namespace backend_proyecto.model
{
    public class Employedproject
    {
        public int Id { get; set; }
        public virtual required int EmpleadoId { get; set; }
        public virtual required int ProyectoId { get; set; }

        public required bool IsDeleted { get; set; }
        public required Employed Employed { get; set; }
        public required Project Project { get; set; }
    }
}