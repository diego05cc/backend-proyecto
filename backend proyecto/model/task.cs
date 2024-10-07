namespace backend_proyecto.model
{
    public class Task
    {
        public int Id { get; set; }

        public required string user  { get; set; }

        public required string titulo { get; set; }

        public required DateTime fecha_incio { get; set; }

        public required DateTime fecha_fin { get; set; }

        public required float progreso { get; set; }

        public int User { get; set; }

       

    }
}
