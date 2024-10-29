using AWEPP.Repositories;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;

public class EmployedRepository : IEmployedRepository
{
    private readonly TimeTrackingContext _context;

    public EmployedRepository(TimeTrackingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employed>> GetAllEmployedsAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employed> GetEmployedByIdAsync(int id)
    {
        return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Employed> CreateEmployedAsync(Employed employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employed> UpdateEmployedAsync(Employed employee)
    {
        _context.Entry(employee).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employed> SoftDeleteEmployedAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            employee.IsDeleted = true;
            await _context.SaveChangesAsync();
            return employee; // Devuelve el empleado eliminado
        }
        return null; // Si no se encuentra el empleado, devuelve null
    }
}
