
using backend_proyecto.model;

namespace AWEPP.Services
{
    public interface EmployedprojectServices
    {
        Task<IEnumerable<Employedproject>> GetAllEmployedprojecsAsync();
        Task<Employedproject> GetEmployedprojecByIdAsync(int id);
        Task<Employedproject> CreateEmployedprojecAsync(Employedproject employedproject);
        Task<Employedproject> UpdateEmployedprojecAsync(Employedproject employedproject);
        backend_proyecto.model.Tasks SoftDeleteEmployedprojecAsync(int id);
    }
}