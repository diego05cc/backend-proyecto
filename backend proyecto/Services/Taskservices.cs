using backend_proyecto.DTOs;
using backend_proyecto.model;
using backend_proyecto.Repositories;
using backend_proyecto.Services;

namespace backend_proyecto.Services
{
    public class Taskservices : ITaskservices
    {
        private readonly ITasksRepository _tasksRepository;

        public Taskservices(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task CreateTaskAsync(Tasks task)
        {
            await _tasksRepository.CreateTaskAsync(task);
        }

        public Task CreateTaskAsync(DTOTasks task)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tasks>> GetAllTasksAsync()
        {
            return await _tasksRepository.GetAllTasksAsync();
        }

        public async Task<Tasks> GetTaskByIdAsync(int id)
        {
            return await _tasksRepository.GetTaskByIdAsync(id);
        }

        public async Task SoftDeleteTaskAsync(int id)
        {
            await _tasksRepository.SoftDeleteTaskAsync(id);
        }

        public async Task UpdateTaskAsync(Tasks task)
        {
            await _tasksRepository.UpdateTaskAsync(task);
        }

        public Task UpdateTaskAsync(DTOTasks task)
        {
            throw new NotImplementedException();
        }
    }
}