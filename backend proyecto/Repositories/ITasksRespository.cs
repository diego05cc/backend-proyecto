using backend_proyecto.model;
using System.Threading.Tasks;

namespace backend_proyecto.Repositories
{
    public interface ITasksRepository
    {
        Task<List<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(Tasks task);
        Task UpdateTaskAsync(Tasks task);
        Task SoftDeleteTaskAsync(Tasks task);
    }
}