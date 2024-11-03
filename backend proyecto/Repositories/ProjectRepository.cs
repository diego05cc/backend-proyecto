using backend_proyecto.Context;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace backend_proyecto.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TimeTrackingContext _context;

        public ProjectRepository(TimeTrackingContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public async Task CreateProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteProjectAsync(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}