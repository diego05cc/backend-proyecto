using backend_proyecto.model;

namespace backend_proyecto.repositories
{
    public interface ITasksRepository
    {
        Task<IEnumerable<DTOTasks>> GetAllTasksAsync();
        Task<DTOTasks> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(DTOTasks task);
        Task UpdateTaskAsync(DTOTasks task);
        Task SoftDeleteTaskAsync(int id);
    }
}