using backend_proyecto.Context;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace backend_proyecto.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly TimeTrackingContext _context;

        public TasksRepository(TimeTrackingContext context)
        {
            _context = context;
        }

        public async Task<List<Tasks>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Tasks> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
        }

        public async Task CreateTaskAsync(Tasks task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(Tasks task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteTaskAsync(Tasks task)
        {
            task.IsDeleted = true;
            await UpdateTaskAsync(task);
        }
    }
}