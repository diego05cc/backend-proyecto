using backend_proyecto.Repositories;
using backend_proyecto.model;

public class TasksService
{
    private readonly ITasksRepository _repository;

    public TasksService(ITasksRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Tasks>> GetAllTaskssAsync()
    {
        return await _repository.GetAllTaskssAsync();
    }

    public async Task<Tasks> GetTasksByIdAsync(int id)
    {
        return await _repository.GetTasksByIdAsync(id);
    }

    public async Task<Tasks> CreateTasksAsync(Tasks task)
    {
        // Puedes agregar validaciones o lógica adicional antes de crear la tarea
        return await _repository.CreateTasksAsync(task);
    }

    public async Task<Tasks> UpdateTasksAsync(Tasks task)
    {
        // Puedes agregar validaciones o lógica adicional antes de actualizar la tarea
        return await _repository.UpdateTasksAsync(task);
    }

    public async Task SoftDeleteTasksAsync(int id)
    {
        await _repository.SoftDeleteTasksAsync(id);
    }
}