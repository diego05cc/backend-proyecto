using backend_proyecto.Repositories;
using backend_proyecto.model;

public class ProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        return await _repository.GetAllProjectsAsync();
    }

    public async Task<Project> GetProjectByIdAsync(int id)
    {
        return await _repository.GetProjectByIdAsync(id);
    }

    public async Task<Project> CreateProjectAsync(Project project)
    {
        // Puedes agregar validaciones o lógica adicional antes de crear el proyecto
        return await _repository.CreateProjectAsync(project);
    }

    public async Task<Project> UpdateProjectAsync(Project project)
    {
        // Puedes agregar validaciones o lógica adicional antes de actualizar el proyecto
        return await _repository.UpdateProjectAsync(project);
    }

    public async Task SoftDeleteProjectAsync(int id)
    {
        await _repository.SoftDeleteProjectAsync(id);
    }
}