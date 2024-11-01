
using backend_proyecto.Repositories;
using backend_proyecto.model;
using System.Threading.Tasks;


namespace backend_proyecto.Services
{
    public interface IEmployedservices
    {
        Task<IEnumerable<Employed>> GetAllEmployedsAsync();
        Task<Employed> GetEmployedByIdAsync(int id);
        Task CreateEmployedAsync(Employed employed);
        Task UpdateEmployedAsync(Employed employed);

        Task SoftDeleteEmployedAsync(int id);
    }
}


