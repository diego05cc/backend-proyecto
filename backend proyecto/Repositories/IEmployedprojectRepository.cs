using AWEPP.Repositories;
using backend_proyecto.model; 
using Microsoft.EntityFrameworkCore;


    public class EmployedprojectRepository : IEmployedprojectRepository
{
        private readonly TimeTrackingContext _context;

        public EmployedprojectRepository(TimeTrackingContext context)
    {
            _context = context;
    }

    public async Task<IEnumerable<Employedproject>> GetAllEmployedprojectsAsync() 
    {
        return await _context.Employedprojects.ToListAsync();
    }

    public async Task<Employedproject> GetEmployedprojectsAsync(int id)
    {
        return await _context.Employedprojects.FirstOrDefaultAsync(e => e.EmpleadoId == id);
    }

    public async Task<Employedproject> CreateEmployedprojectAsync(Employedproject employedproject)
    {
        _context.Employedprojects.Add(employedproject);
        await _context.SaveChangesAsync();
        return employedproject;
    }

    public async Task<Employedproject> UpdateEmployedprojectAsync(Employedproject employedproject)
    {
        _context.Entry(employedproject).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return employedproject;
    }

    public async System.Threading.Tasks.Task SoftDeleteEmployedprojectAsync(int id)
    {
        var employedproject = await _context.Employedprojects.FindAsync(id);
        if (employedproject != null)
        {
            employedproject.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }

    public Task<Employedproject> GetEmployedprojectByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<Employedproject> IEmployedprojectRepository.SoftDeleteEmployedprojectAsync(int id)
    {
        throw new NotImplementedException();
    }
}