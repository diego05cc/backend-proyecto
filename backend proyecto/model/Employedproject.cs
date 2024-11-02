namespace backend_proyecto.model
{
    public class Employedproject
    {
        public int Id { get; set; }
        public virtual required int EmpleadoId { get; set; }
        public virtual required int ProyectoId { get; set; }

        public  bool IsDeleted { get; set; }
        public virtual  Employed Employed { get; set; }
        public virtual Project Project { get; set; }
    }
}