
using AWEPP.Repositories;
using backend_proyecto.model;
using System.Threading.Tasks;


namespace AWEPP.Services
{
    public interface EmployedServices
    {
        Task<IEnumerable<Employed>> GetAllEmployedsAsync();
        Task<Employed> GetEmployedByIdAsync(int id);
        Task<Employed> CreateEmployedAsync(Employed employed);
        Task<Employed> UpdateEmployedAsync(Employed employed);

        backend_proyecto.model.Tasks SoftDeleteEmployedAsync(int id);
    }
}


