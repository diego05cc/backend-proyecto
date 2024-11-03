using backend_proyecto.Context;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace backend_proyecto.Repositories
{
    public class RegisteroftimeRepository : IRegisteroftimeRepository
    {
        private readonly TimeTrackingContext _context;

        public RegisteroftimeRepository(TimeTrackingContext context)
        {
            _context = context;
        }

        public async Task<List<Registeroftime>> GetAllRegisteroftimesAsync()
        {
            return await _context.Registeroftimes.ToListAsync();
        }

        public async Task<Registeroftime> GetRegisteroftimeByIdAsync(int id)
        {
            return await _context.Registeroftimes.FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
        }

        public async Task CreateRegisteroftimeAsync(Registeroftime registeroftime)
        {
            await _context.Registeroftimes.AddAsync(registeroftime);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRegisteroftimeAsync(Registeroftime registeroftime)
        {
            _context.Registeroftimes.Update(registeroftime);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteRegisteroftimeAsync(Registeroftime registeroftime)
        {
            registeroftime.IsDeleted = true;
            await UpdateRegisteroftimeAsync(registeroftime);
        }
    }
}