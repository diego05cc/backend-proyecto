using AWEPP.Repositories;
using backend_proyecto.model;

public class EmployedService
{
    private readonly IEmployedRepository _repository;

    public EmployedService(IEmployedRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Employed>> GetAllEmployedsAsync()
    {
        return await _repository.GetAllEmployedsAsync();
    }

    public async Task<Employed> GetEmployedByIdAsync(int id)
    {
        return await _repository.GetEmployedByIdAsync(id);
    }

    public async Task<Employed> CreateEmployedAsync(Employed employed)
    {
        // Puedes agregar validaciones o lógica adicional antes de crear el empleado
        return await _repository.CreateEmployedAsync(employed);
    }

    public async Task<Employed> UpdateEmployedAsync(Employed employed)
    {
        // Puedes agregar validaciones o lógica adicional antes de actualizar el empleado
        return await _repository.UpdateEmployedAsync(employed);
    }

    public async Task<Employed> SoftDeleteEmployedAsync(int id)
    {
        return await _repository.SoftDeleteEmployedAsync(id);
    }
}