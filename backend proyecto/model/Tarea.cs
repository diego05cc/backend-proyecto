namespace backend_proyecto.model
{
    public class Tarea
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public int ProyectoId { get; set; }
        public required Proyecto Proyecto { get; set; }
        public required ICollection<RegistroDeTiempo> RegistrosDeTiempo { get; set; }
    }
}