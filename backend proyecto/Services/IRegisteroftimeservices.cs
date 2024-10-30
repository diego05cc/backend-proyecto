using AWEPP.Repositories;
using backend_proyecto.model;

public class RegisteroftimeService
{
    private readonly IRegisteroftimeRepository _repository;

    public RegisteroftimeService(IRegisteroftimeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Registeroftime>> GetAllRegisteroftimesAsync()
    {
        return await _repository.GetAllRegisteroftimesAsync();
    }

    public async Task<Registeroftime> GetRegisteroftimeByIdAsync(int id)
    {
        return await _repository.GetRegisteroftimeByIdAsync(id);
    }

    public async Task<Registeroftime> CreateRegisteroftimeAsync(Registeroftime registeroftime)
    {
        // Puedes agregar validaciones o lógica adicional antes de crear el registro
        return await _repository.CreateRegisteroftimeAsync(registeroftime);
    }

    public async Task<Registeroftime> UpdateRegisteroftimeAsync(Registeroftime registeroftime)
    {
        // Puedes agregar validaciones o lógica adicional antes de actualizar el registro
        return await _repository.UpdateRegisteroftimeAsync(registeroftime);
    }

    public async Task SoftDeleteRegisteroftimeAsync(int id)
    {
        await _repository.SoftDeleteRegisteroftimeAsync(id);
    }
}