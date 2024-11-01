using backend_proyecto.model;

namespace backend_proyecto.Repositories
{
    public interface IRegisteroftimeRepository
    {
        Task<IEnumerable<Registeroftime>> GetAllRegisteroftimesAsync();
        Task<Registeroftime> GetRegisteroftimeByIdAsync(int id);
        Task<Registeroftime> CreateRegisteroftimeAsync(Registeroftime registeroftime);
        Task<Registeroftime> UpdateRegisteroftimeAsync(Registeroftime registeroftime);
        Task SoftDeleteRegisteroftimeAsync(int id);
    }
}
