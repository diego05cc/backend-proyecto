using backend_proyecto.model;
using System.Threading.Tasks;

namespace backend_proyecto.Services
{
    public interface ITaskservices
    {
        Task<List<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTaskByIdAsync(int id);
        Task<Tasks> CreateTaskAsync(string nombre, string descripcion, int proyectoId, bool IsDeleted);
        Task<Tasks> UpdateTaskAsync(int id, string nombre, string descripcion, int proyectoId,bool IsDeleted);
        Task<Tasks> SoftDeleteTaskAsync(int id);
    }
}