using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;
using Task = backend_proyecto.model.Task;

namespace backend_proyecto.context
{
    public class TestDbRH : DbContext
    {
        private object withmany;

        public TestDbRH (DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> users { get; set; }

        public DbSet<UserType> userTypes { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Task> Documents { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u => u.id);




        }

     
        
    }
}
