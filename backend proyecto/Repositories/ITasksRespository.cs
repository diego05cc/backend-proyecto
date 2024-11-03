using backend_proyecto.model;

namespace backend_proyecto.repositories
{
    public interface ITasksRepository
    {
        Task<IEnumerable<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(Tasks task);
        Task UpdateTaskAsync(Tasks task);
        Task SoftDeleteTaskAsync(int id);
    }
}