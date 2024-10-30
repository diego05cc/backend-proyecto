using AWEPP.Repositories;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;

public class ProjectRepository : IProjectRepository
{
    private readonly TimeTrackingContext _context;

    public ProjectRepository(TimeTrackingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Project> GetProjectByIdAsync(int id)
    {
        return await _context.Projects.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Project> CreateProjectAsync(Project Projects)
    {
        _context.Projects.Add(Projects);
        await _context.SaveChangesAsync();
        return Projects;
    }

    public async Task<Project> UpdateProjectAsync(Project Projects)
    {
        _context.Entry(Projects).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Projects;
    }

    public async Task<Project> SoftDeleteProjectAsync(int id)
    {
        var Projects = await _context.Projects.FindAsync(id);
        if (Projects != null)
        {
            Projects.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Projects; 
        }
        return null; 
    }
}
