using backend_proyecto.model;
using System.Threading.Tasks;

namespace backend_proyecto.Repositories
{
    public interface IRegisteroftimeRepository
    {
        Task<List<Registeroftime>> GetAllRegisteroftimesAsync();
        Task<Registeroftime> GetRegisteroftimeByIdAsync(int id);
        Task CreateRegisteroftimeAsync(Registeroftime registeroftime);
        Task UpdateRegisteroftimeAsync(Registeroftime registeroftime);
        Task SoftDeleteRegisteroftimeAsync(Registeroftime registeroftime);
    }
}