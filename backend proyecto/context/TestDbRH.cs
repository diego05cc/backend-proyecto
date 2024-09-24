using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;

namespace backend_proyecto.context
{
    public class TestDbRH : DbContext
    {
        public TestDbRH (DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u => u.id);

        }
    }
}
