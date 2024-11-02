using backend_proyecto.Context;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;

namespace backend_proyecto.repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TimeTrackingContext _context;

        public ProjectRepository(TimeTrackingContext context)
        {
            _context = context;
        }

        public async Task CreateProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .Where(p => !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public async Task SoftDeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                project.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProjectAsync(Project project)
        {
            var existingProject = await _context.Projects.FindAsync(project.Id);
            if (existingProject != null)
            {
                existingProject.Nombre = project.Nombre;
                existingProject.Descripcion = project.Descripcion;
                existingProject.FechaInicio = project.FechaInicio;
                existingProject.FechaFin = project.FechaFin;

                await _context.SaveChangesAsync();
            }
        }
    }
}