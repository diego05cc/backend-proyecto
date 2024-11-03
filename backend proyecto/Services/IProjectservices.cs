using backend_proyecto.model;
using System.Threading.Tasks;

namespace backend_proyecto.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<Project> CreateProjectAsync(string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin);
        Task<Project> UpdateProjectAsync(int id, string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin);
        Task<Project> SoftDeleteProjectAsync(int id);
    }
}