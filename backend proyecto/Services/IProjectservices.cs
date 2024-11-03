using backend_proyecto.model;
using System.Threading.Tasks;

namespace backend_proyecto.Services
{
    public interface IProjectservices
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<Project> CreateProjectAsync(string Nombre, string Descripcion, DateTime FechaInicio, DateTime FechaFin, bool IsDeleted);
        Task<Project> UpdateProjectAsync(int id, string Nombre, string Descripcion, DateTime FechaInicio, DateTime FechaFin, bool IsDeleted);
        Task<Project> SoftDeleteProjectAsync(int id);
    }
}