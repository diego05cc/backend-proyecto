using backend_proyecto.Repositories;
using backend_proyecto.model;
using backend_proyecto.Services;
using System.Threading.Tasks;

namespace backend_proyecto.Services
{
    public class Taskservices : ITaskservices
    {
        private readonly ITasksRepository _repository;

        public Taskservices(ITasksRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Tasks>> GetAllTasksAsync()
        {
            return _repository.GetAllTasksAsync();
        }

        public Task<Tasks> GetTaskByIdAsync(int id)
        {
            return _repository.GetTaskByIdAsync(id);
        }

        public async Task<Tasks> CreateTaskAsync(string nombre, string descripcion, int proyectoId, bool IsDeleted)
        {
            var newTask = new Tasks
            {
                Nombre = nombre,
                Descripcion = descripcion,
                ProyectoId = proyectoId,
                IsDeleted = IsDeleted
            };
            await _repository.CreateTaskAsync(newTask);
            return newTask;
        }

        public async Task<Tasks> UpdateTaskAsync(int id, string nombre, string descripcion, int proyectoId, bool IsDeleted)
        {
            var taskToUpdate = await _repository.GetTaskByIdAsync(id);
            if (taskToUpdate != null)
            {
                taskToUpdate.Nombre = nombre;
                taskToUpdate.Descripcion = descripcion;
                taskToUpdate.ProyectoId = proyectoId;
                taskToUpdate.IsDeleted = IsDeleted;
                await _repository.UpdateTaskAsync(taskToUpdate);
            }
            return taskToUpdate;
        }

        public async Task<Tasks> SoftDeleteTaskAsync(int id)
        {
            var taskToDelete = await _repository.GetTaskByIdAsync(id);
            if (taskToDelete != null)
            {
                await _repository.SoftDeleteTaskAsync(taskToDelete);
            }
            return taskToDelete;
        }
    }
}