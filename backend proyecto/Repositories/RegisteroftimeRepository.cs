using backend_proyecto.Context;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;

namespace backend_proyecto.repositories
{
    public class RegisteroftimeRepository : IRegisteroftimeRepository
    {
        private readonly TimeTrackingContext _context;

        public RegisteroftimeRepository(TimeTrackingContext context)
        {
            _context = context;
        }

        public async Task CreateRegisteroftimeAsync(Registeroftime registeroftime)
        {
            await _context.Registeroftimes.AddAsync(registeroftime);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Registeroftime>> GetAllRegisteroftimesAsync()
        {
            return await _context.Registeroftimes
                .Where(r => !r.IsDeleted)
                .ToListAsync();
        }

        public async Task<Registeroftime> GetRegisteroftimeByIdAsync(int id)
        {
            return await _context.Registeroftimes
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
        }

        public async Task SoftDeleteRegisteroftimeAsync(int id)
        {
            var registeroftime = await _context.Registeroftimes.FindAsync(id);
            if (registeroftime != null)
            {
                registeroftime.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateRegisteroftimeAsync(Registeroftime registeroftime)
        {
            var existingRegisteroftime = await _context.Registeroftimes.FindAsync(registeroftime.Id);
            if (existingRegisteroftime != null)
            {
                existingRegisteroftime.EmpleadoId = registeroftime.EmpleadoId;
                existingRegisteroftime.TareaId = registeroftime.TareaId;
                existingRegisteroftime.Fecha = registeroftime.Fecha;
                existingRegisteroftime.HoraInicio = registeroftime.HoraInicio;
                existingRegisteroftime.HoraFin = registeroftime.HoraFin;
                existingRegisteroftime.Descripcion = registeroftime.Descripcion;

                await _context.SaveChangesAsync();
            }
        }
    }
}