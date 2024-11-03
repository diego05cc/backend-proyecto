using backend_proyecto.DTOs;
using backend_proyecto.model;

namespace backend_proyecto.services
{
    public interface ITasksService
    {
        Task<IEnumerable<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(Tasks task);
        Task UpdateTaskAsync(Tasks task);
        Task SoftDeleteTaskAsync(int id);
        Task CreateTaskAsync(DTOTasks task);
        Task UpdateTaskAsync(DTOTasks task);
    }
}