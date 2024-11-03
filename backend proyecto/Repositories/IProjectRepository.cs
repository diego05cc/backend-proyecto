using backend_proyecto.model;
using System.Threading.Tasks;

namespace backend_proyecto.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task SoftDeleteProjectAsync(Project project);
    }
}