using backend_proyecto.model;
using backend_proyecto.repositories;

namespace backend_proyecto.services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task CreateTaskAsync(DTOTasks task)
        {
            await _tasksRepository.CreateTaskAsync(task);
        }

        public async Task<IEnumerable<DTOTasks>> GetAllTasksAsync()
        {
            return await _tasksRepository.GetAllTasksAsync();
        }

        public async Task<DTOTasks> GetTaskByIdAsync(int id)
        {
            return await _tasksRepository.GetTaskByIdAsync(id);
        }

        public async Task SoftDeleteTaskAsync(int id)
        {
            await _tasksRepository.SoftDeleteTaskAsync(id);
        }

        public async Task UpdateTaskAsync(DTOTasks task)
        {
            await _tasksRepository.UpdateTaskAsync(task);
        }
    }
}