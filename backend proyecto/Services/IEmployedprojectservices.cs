using backend_proyecto.model;
using backend_proyecto.Repositories;

namespace backend_proyecto.services
{
    public interface IEmployedProjectService
    {
        Task<List<Employedproject>> GetAllEmployedProjectAsync();
        Task<Employedproject> GetEmployedProjectByIdAsync(int Id);
        Task<Employedproject> CreateEmployedProjectAsync(int EmpleadoId, int ProyectoId, bool IsDeleted);
        Task<Employedproject> UpdateEmployedProjectAsync(int Id, int EmpleadoId, int ProyectoId, bool IsDeleted);
        Task<Employedproject> SoftDeleteEmployedProjectAsync(int Id);
    }
}