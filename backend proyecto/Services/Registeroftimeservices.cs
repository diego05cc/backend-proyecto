
using AWEPP.Repositories;
using backend_proyecto.model;
using System.Threading.Tasks;


namespace AWEPP.Services
{
    public interface RegisteroftimeServices
    {
        Task<IEnumerable<Registeroftime>> GetAllRegisteroftimesAsync();
        Task<Registeroftime> GetRegisteroftimeByIdAsync(int id);
        Task<Registeroftime> CreateRegisteroftimeAsync(Registeroftime registeroftime);
        Task<Registeroftime> UpdateRegisteroftimeAsync(Registeroftime registeroftime);
        backend_proyecto.model.Tasks SoftDeleteRegisteroftimeAsync(int id);
    }
}