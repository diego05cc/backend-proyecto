namespace backend_proyecto.model
{
    public class Tasks
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public int ProyectoId { get; set; }
        public bool IsDeleted { get; set; }
        public required Project Project { get; set; }
        public List<Registeroftime> Registeroftimes { get; set; }
    }
}