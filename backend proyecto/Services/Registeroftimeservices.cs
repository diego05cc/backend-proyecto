using backend_proyecto.Repositories;
using backend_proyecto.model;
using System.Threading.Tasks;

using backend_proyecto.Services;

namespace backend_proyecto.Services
{
    public class Registeroftimeservices : IRegisteroftimeservices
    {
        private readonly IRegisteroftimeRepository _repository;

        public Registeroftimeservices(IRegisteroftimeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Registeroftime>> GetAllRegisteroftimesAsync()
        {
            return _repository.GetAllRegisteroftimesAsync();
        }

        public Task<Registeroftime> GetRegisteroftimeByIdAsync(int id)
        {
            return _repository.GetRegisteroftimeByIdAsync(id);
        }

        public async Task<Registeroftime> CreateRegisteroftimeAsync(int empleadoId, int tareaId, DateTime fecha, DateTime horaInicio, DateTime horaFin, string descripcion,bool IsDeleted)
        {
            var newRegisteroftime = new Registeroftime
            {
                EmpleadoId = empleadoId,
                TareaId = tareaId,
                Fecha = fecha,
                HoraInicio = horaInicio,
                HoraFin = horaFin,
                Descripcion = descripcion,
                IsDeleted = IsDeleted
            };
            await _repository.CreateRegisteroftimeAsync(newRegisteroftime);
            return newRegisteroftime;
        }

        public async Task<Registeroftime> UpdateRegisteroftimeAsync(int id, int empleadoId, int tareaId, DateTime fecha, DateTime horaInicio, DateTime horaFin, string descripcion,bool IsDeleted)
        {
            var registeroftimeToUpdate = await _repository.GetRegisteroftimeByIdAsync(id);
            if (registeroftimeToUpdate != null)
            {
                registeroftimeToUpdate.EmpleadoId = empleadoId;
                registeroftimeToUpdate.TareaId = tareaId;
                registeroftimeToUpdate.Fecha = fecha;
                registeroftimeToUpdate.HoraInicio = horaInicio;
                registeroftimeToUpdate.HoraFin = horaFin;
                registeroftimeToUpdate.Descripcion = descripcion;
                registeroftimeToUpdate.IsDeleted = IsDeleted;
                await _repository.UpdateRegisteroftimeAsync(registeroftimeToUpdate);
            }
            return registeroftimeToUpdate;
        }

        public async Task<Registeroftime> SoftDeleteRegisteroftimeAsync(int id)
        {
            var registeroftimeToDelete = await _repository.GetRegisteroftimeByIdAsync(id);
            if (registeroftimeToDelete != null)
            {
                await _repository.SoftDeleteRegisteroftimeAsync(registeroftimeToDelete);
            }
            return registeroftimeToDelete;
        }
    }
}