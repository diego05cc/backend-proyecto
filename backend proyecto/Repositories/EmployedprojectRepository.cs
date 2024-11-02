using backend_proyecto.Repositories;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;
using backend_proyecto.Context;

namespace backend_proyecto.Repositories
{
    public class EmployedProjectRepository : IEmployedProjectRepository
    {
        private readonly TimeTrackingContext  _context; // Replace with your actual DbContext class

        public EmployedProjectRepository(TimeTrackingContext context)
        {
            _context = context;
        }

        public async Task CreateEmployedProjectAsync(Employedproject employedProject)
        {
            await _context.EmployedProjects.AddAsync(employedProject);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employedproject>> GetAllEmployedProjectAsync()
        {
            return await _context.EmployedProjects.ToListAsync();
        }

        public async Task<Employedproject> GetEmployedProjectByIdAsync(int id)
        {
            return await _context.EmployedProjects.FindAsync(id);
              
        }

        public async Task SoftDeleteEmployedProjectAsync(Employedproject employedproject)
        {
            _context.EmployedProjects.Remove(employedproject);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployedProjectAsync(Employedproject employedProject)
        {
            _context.EmployedProjects.Update(employedProject);
            await _context.SaveChangesAsync();
        }
    }
}