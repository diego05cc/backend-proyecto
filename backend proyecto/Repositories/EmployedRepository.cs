using backend_proyecto.model;

namespace AWEPP.Repositories
{
    public interface IEmployedRepository
    {
        Task<IEnumerable<Employed>> GetAllEmployedsAsync();
        Task<Employed> GetEmployedByIdAsync(int id);
        Task<Employed> CreateEmployedAsync(Employed Employed);
        Task<Employed> UpdateEmployedAsync(Employed Employed);
        Task<Employed> SoftDeleteEmployedAsync(int id);

    }



}

