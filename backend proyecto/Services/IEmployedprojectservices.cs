using backend_proyecto.Repositories;
using backend_proyecto.model;

public class EmployedprojectService
{
    private readonly IEmployedprojectRepository _repository;

    public EmployedprojectService(IEmployedprojectRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Employedproject>> GetAllEmployedprojectsAsync()
    {
        return await _repository.GetAllEmployedprojectsAsync();
    }

    public async Task<Employedproject> GetEmployedprojectByIdAsync(int id)
    {
        return await _repository.GetEmployedprojectByIdAsync(id);
    }

    public async Task<Employedproject> CreateEmployedprojectAsync(Employedproject employedproject)
    {
        // Aquí puedes agregar lógica de validación o transformación de datos antes de guardar
        return await _repository.CreateEmployedprojectAsync(employedproject);
    }

    public async Task<Employedproject> UpdateEmployedprojectAsync(Employedproject employedproject)
    {
        // Aquí puedes agregar lógica de validación o transformación de datos antes de actualizar
        return await _repository.UpdateEmployedprojectAsync(employedproject);
    }

    public async Task SoftDeleteEmployedprojectAsync(int id)
    {
        await _repository.SoftDeleteEmployedprojectAsync(id);
    }
}