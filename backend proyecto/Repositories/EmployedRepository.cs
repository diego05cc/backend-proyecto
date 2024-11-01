using backend_proyecto.Repositories;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;
using backend_proyecto.Context;

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
        return await _context.Employees.FirstOrDefaultAsync(e => e.Employed_Id == id && !e.IsDeleted);
    }

    public async Task CreateEmployedAsync(Employed employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        
    }

    public async Task UpdateEmployedAsync(Employed employee)
    {
        var existingEmployed = await _context.Employees.FindAsync(employee.Employed_Id);
        if (existingEmployed != null)
        { 
         existingEmployed.Apellido = employee.Apellido;
            existingEmployed.Cargo = employee.Cargo;
            existingEmployed.Departamento = employee.Departamento;
            existingEmployed.Nombre = employee.Nombre;
            existingEmployed.IsDeleted = employee.IsDeleted;
        }
        await _context.SaveChangesAsync();
        
    }

    public async Task SoftDeleteEmployedAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            employee.IsDeleted = true;
            await _context.SaveChangesAsync();
             // Devuelve el empleado eliminado
        }
         // Si no se encuentra el empleado, devuelve null
    }
}
