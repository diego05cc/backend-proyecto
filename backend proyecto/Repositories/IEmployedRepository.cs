using backend_proyecto.model;

namespace backend_proyecto.Repositories
{
    public interface IEmployedRepository
    {
        Task<IEnumerable<Employed>> GetAllEmployedsAsync();
        Task<Employed> GetEmployedByIdAsync(int id);
        Task CreateEmployedAsync(Employed Employed);
        Task UpdateEmployedAsync(Employed Employed);
        Task SoftDeleteEmployedAsync(int id);

    }



}

