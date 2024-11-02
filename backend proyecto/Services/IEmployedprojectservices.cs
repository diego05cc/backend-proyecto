using backend_proyecto.model;

namespace backend_proyecto.services
{
    public interface IEmployedProjectService
    {
        Task<IEnumerable<Employedproject>> GetAllEmployedProjectAsync();
        Task<Employedproject> GetEmployedProjectByIdAsync(int id);
        Task CreateEmployedProjectAsync(Employedproject employedProject);
        Task UpdateEmployedProjectAsync(Employedproject employedProject);
        Task SoftDeleteEmployedProjectAsync(int id);
    }
}