using backend_proyecto.model;

namespace backend_proyecto.services
{
    public interface IProjectService
    {
        Task<IEnumerable<DTOProject>> GetAllProjectsAsync();
        Task<DTOProject> GetProjectByIdAsync(int id);
        Task CreateProjectAsync(DTOProject project);
        Task UpdateProjectAsync(DTOProject project);
        Task SoftDeleteProjectAsync(int id);
    }
}