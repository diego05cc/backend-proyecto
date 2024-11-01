using backend_proyecto.model;

namespace backend_proyecto.Repositories
{
    public interface ITasksRepository
    {
        Task<IEnumerable<Tasks>> GetAllTaskssAsync();
        Task<Tasks> GetTasksByIdAsync(int id);
        Task<Tasks> CreateTasksAsync(Tasks tasks);
        Task<Tasks> UpdateTasksAsync(Tasks tasks);
        Task<Tasks> SoftDeleteTasksAsync(int id);

    }

}

