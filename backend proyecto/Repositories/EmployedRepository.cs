using backend_proyecto.Repositories;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;
using backend_proyecto.Context;
using backend_proyecto.DTOs;

namespace backend_proyecto.Repositories
{
    public class EmployedRepository : IEmployedRepository
    {
        private readonly TimeTrackingContext _context;

        public EmployedRepository(TimeTrackingContext context)
        {
            _context = context;
        }

        public async Task<List<Employed>> GetAllEmployedsAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employed> GetEmployedByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Employed_Id == id && !e.IsDeleted);
        }

        public async Task CreateEmployedAsync(Employed employed)
        {
            await _context.Employees.AddAsync(employed);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateEmployedAsync(Employed employed)
        {
            _context.Employees.Update(employed);
            await _context.SaveChangesAsync();

        }

        public async Task SoftDeleteEmployedAsync(Employed employed)
        {
            _context.Employees.Remove(employed);
            await _context.SaveChangesAsync();
            // Si no se encuentra el empleado, devuelve null
        }
    }
}