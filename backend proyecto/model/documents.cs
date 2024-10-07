namespace backend_proyecto.model
{
    public class Documents
    {
        public int Id { get; set; }

        public required string Document { get; set; }

        public required string Typedocument { get; set; }

        public required DateTime Timedocument { get; set; }
    }
}
