using Microsoft.EntityFrameworkCore;
using backend_proyecto.model;
using backend_proyecto.Context;

namespace backend_proyecto.Repositories
{
    public interface IEmployedProjectRepository
    {
        Task<List<Employedproject>> GetAllEmployedProjectAsync();
        Task<Employedproject> GetEmployedProjectByIdAsync(int id);
        Task CreateEmployedProjectAsync(Employedproject employedProject);
        Task UpdateEmployedProjectAsync(Employedproject employedProject);
        Task SoftDeleteEmployedProjectAsync(Employedproject employedproject);
    }
}