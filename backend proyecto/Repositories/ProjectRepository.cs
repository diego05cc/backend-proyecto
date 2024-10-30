using backend_proyecto.model;

namespace AWEPP.Repositories
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