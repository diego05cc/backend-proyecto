using backend_proyecto.model;

namespace backend_proyecto.Repositories
{
    public interface IEmployedprojectRepository
    {
        Task<IEnumerable<Employedproject>> GetAllEmployedprojectsAsync();
        Task<Employedproject> GetEmployedprojectByIdAsync(int id);
        Task<Employedproject> CreateEmployedprojectAsync(Employedproject employedproject);
        Task<Employedproject> UpdateEmployedprojectAsync(Employedproject employedproject);
        Task<Employedproject> SoftDeleteEmployedprojectAsync(int id);
     }
}