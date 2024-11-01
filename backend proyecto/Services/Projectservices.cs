
using backend_proyecto.Repositories;
using backend_proyecto.model;
using System.Threading.Tasks;


namespace backend_proyecto.Services
{
    public interface ProjectServices
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<Project> CreateProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(Project project);
        backend_proyecto.model.Tasks SoftDeleteProjectAsync(int id);
    }
}