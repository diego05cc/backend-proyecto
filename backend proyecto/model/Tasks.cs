namespace backend_proyecto.model
{
    public class Tasks
    {
        public int Id { get; set; }
        public  string Nombre { get; set; }
        public  string Descripcion { get; set; }
        public int ProyectoId { get; set; }
        public bool IsDeleted { get; set; }
        public  Project Project { get; set; }
        public List<Registeroftime> Registeroftimes { get; set; }
    }
}