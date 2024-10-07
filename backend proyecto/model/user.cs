namespace backend_proyecto.model
{
    public class User
    {
        public int id { get; set; }
        public required string name { get; set; }

        public required string email { get; set; }

        public virtual required UserType UserType { get; set; }

        public virtual required Task TaskId { get; set; }

        public required ICollection<Task> TasksId { get; set; }
        public required Task Task { get; set; }

    }
}


