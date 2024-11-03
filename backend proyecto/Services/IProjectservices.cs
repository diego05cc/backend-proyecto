using backend_proyecto.DTOs;
using backend_proyecto.model;

namespace backend_proyecto.services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task SoftDeleteProjectAsync(int id);
        Task CreateProjectAsync(DTOProject project);
        Task UpdateProjectAsync(DTOProject projectDTO);
    }
}