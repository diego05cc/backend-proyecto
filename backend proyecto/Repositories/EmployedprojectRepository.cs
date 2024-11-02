using backend_proyecto.Context;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;

namespace backend_proyecto.repositories
{
    public class EmployedProjectRepository : IEmployedProjectRepository
    {
        private readonly TimeTrackingContext _context; // Replace with your actual DbContext class

        public EmployedProjectRepository(TimeTrackingContext context)
        {
            _context = context;
        }

        public async Task CreateEmployedProjectAsync(Employedproject employedProject)
        {
            await _context.EmployedProjects.AddAsync(employedProject);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employedproject>> GetAllEmployedProjectAsync()
        {
            return await _context.EmployedProjects
              .Where(ep => !ep.IsDeleted)
            .ToListAsync();
        }

        public async Task<Employedproject> GetEmployedProjectByIdAsync(int id)
        {
            return await _context.EmployedProjects
              .FirstOrDefaultAsync(ep => ep.EmpleadoId == id && !ep.IsDeleted);
        }

        public async Task SoftDeleteEmployedProjectAsync(int id)
        {
            var employedProject = await _context.EmployedProjects.FindAsync(id);
            if (employedProject != null)
            {
                employedProject.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEmployedProjectAsync(Employedproject employedProject)
        {
            var existingEmployedProject = await _context.EmployedProjects.FindAsync(employedProject.EmpleadoId);
            if (existingEmployedProject != null)
            {
                // Update specific fields if needed (consider using a mapper)
                existingEmployedProject.EmpleadoId = employedProject.EmpleadoId;
                existingEmployedProject.ProyectoId = employedProject.ProyectoId;

                await _context.SaveChangesAsync();
            }
        }
    }
}