using backend_proyecto.model;

namespace backend_proyecto.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<Project> CreateProjectAsync(Project Project);
        Task<Project> UpdateProjectAsync(Project Project);
        Task<Project> SoftDeleteProjectAsync(int id);

    }


}