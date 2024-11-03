using backend_proyecto.model;
using System.Threading.Tasks;

namespace backend_proyecto.Services
{
    public interface IRegisteroftimeservices
    {
        Task<List<Registeroftime>> GetAllRegisteroftimesAsync();
        Task<Registeroftime> GetRegisteroftimeByIdAsync(int id);
        Task<Registeroftime> CreateRegisteroftimeAsync(int empleadoId, int tareaId, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, string descripcion, bool IsDeleted);
        Task<Registeroftime> UpdateRegisteroftimeAsync(int id, int empleadoId, int tareaId, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, string descripcion, bool IsDeleted);
        Task<Registeroftime> SoftDeleteRegisteroftimeAsync(int id);
    }
}