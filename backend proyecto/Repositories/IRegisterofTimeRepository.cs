using backend_proyecto.Repositories;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;
using backend_proyecto.Context;

public class RegisteroftimeRepository : IRegisteroftimeRepository
{
    private readonly TimeTrackingContext _context;

    public RegisteroftimeRepository(TimeTrackingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Registeroftime>> GetAllRegisteroftimesAsync()
    {
        return await _context.Registeroftimes.ToListAsync();
    }

    public async Task<Registeroftime> GetRegisteroftimeByIdAsync(int id)
    {
        return await _context.Registeroftimes.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Registeroftime> CreateRegisteroftimeAsync(Registeroftime registeroftime)
    {
        _context.Registeroftimes.Add(registeroftime);
        await _context.SaveChangesAsync();
        return registeroftime;
    }

    public async Task<Registeroftime> UpdateRegisteroftimeAsync(Registeroftime registeroftime)
    {
        _context.Entry(registeroftime).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return registeroftime;
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
}