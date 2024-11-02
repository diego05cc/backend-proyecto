using backend_proyecto.model;

namespace backend_proyecto.repositories
{
    public interface IRegisteroftimeRepository
    {
        Task<IEnumerable<DTORegisteroftime>> GetAllRegisteroftimesAsync();
        Task<DTORegisteroftime> GetRegisteroftimeByIdAsync(int id);
        Task CreateRegisteroftimeAsync(DTORegisteroftime registeroftime);
        Task UpdateRegisteroftimeAsync(DTORegisteroftime registeroftime);
        Task SoftDeleteRegisteroftimeAsync(int id);
    }
}