using AWEPP.Repositories;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class TasksRepository : ITasksRepository
{
    private readonly TimeTrackingContext _context;

    public TasksRepository(TimeTrackingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tasks>> GetAllTaskssAsync()
    {
        return await _context.tasks.ToListAsync();
    }

    public async Task<Tasks> GetTasksByIdAsync(int id)
    {
        return await _context.tasks.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Tasks> CreateTasksAsync(Tasks tasks)
    {
        _context.tasks.Add(tasks);
        await _context.SaveChangesAsync();
        return tasks;
    }

    public async Task<Tasks> UpdateTasksAsync(Tasks tasks)
    {
        _context.Entry(tasks).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return tasks;
    }

    public async Task<Tasks> SoftDeleteTasksAsync(int id)
    {
        var tasks = await _context.tasks.FindAsync(id);
        if (tasks != null)
        {
            tasks.IsDeleted = true;
            await _context.SaveChangesAsync();
            return tasks;
        }
        return null;
    }
}

