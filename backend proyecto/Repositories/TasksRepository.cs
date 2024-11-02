using backend_proyecto.Context;
using backend_proyecto.model;
using Microsoft.EntityFrameworkCore;

namespace backend_proyecto.repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly TimeTrackingContext _context;

        public TasksRepository(TimeTrackingContext context)
        {
            _context = context;
        }

        public async Task CreateTaskAsync(DTOTasks task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DTOTasks>> GetAllTasksAsync()
        {
            return await _context.Tasks
                .Where(t => !t.IsDeleted)
                .ToListAsync();
        }

        public async Task<DTOTasks> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
        }

        public async Task SoftDeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                task.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTaskAsync(DTOTasks task)
        {
            var existingTask = await _context.Tasks.FindAsync(task.Id);
            if (existingTask != null)
            {
                existingTask.Nombre = task.Nombre;
                existingTask.Descripcion = task.Descripcion;
                existingTask.ProyectoId = task.ProyectoId;

                await _context.SaveChangesAsync();
            }
        }
    }
}