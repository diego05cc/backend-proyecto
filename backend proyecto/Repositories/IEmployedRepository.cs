using backend_proyecto.model;

namespace backend_proyecto.Repositories
{
    public interface IEmployedRepository
    {
        Task<List<Employed>> GetAllEmployedsAsync();
        Task<Employed> GetEmployedByIdAsync(int id);
        Task CreateEmployedAsync(Employed employed);
        Task UpdateEmployedAsync(Employed employed);
        Task SoftDeleteEmployedAsync(Employed employed);

    }



}

