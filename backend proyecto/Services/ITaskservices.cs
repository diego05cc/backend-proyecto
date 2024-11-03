using backend_proyecto.DTOs;
using backend_proyecto.model;

namespace backend_proyecto.Services
{
    public interface ITaskservices
    {
        Task<IEnumerable<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(Tasks task);
        Task UpdateTaskAsync(Tasks task);
        Task SoftDeleteTaskAsync(int id);
    }
}