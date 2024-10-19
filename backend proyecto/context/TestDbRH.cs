using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;

namespace backend_proyecto.context
{
    public class TestDbRH : DbContext
    {
        private object withmany;

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
