using backend_proyecto.model;

namespace backend_proyecto.services
{
    public interface IRegisteroftimeService
    {
        Task<IEnumerable<DTORegisteroftime>> GetAllRegisteroftimesAsync();
        Task<DTORegisteroftime> GetRegisteroftimeByIdAsync(int id);
        Task CreateRegisteroftimeAsync(DTORegisteroftime registeroftime);
        Task UpdateRegisteroftimeAsync(DTORegisteroftime registeroftime);
        Task SoftDeleteRegisteroftimeAsync(int id);
    }
}