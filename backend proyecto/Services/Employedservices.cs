using backend_proyecto.Repositories;
using backend_proyecto.model;

namespace backend_proyecto.Services
{
    public class Employedservices : IEmployedservices
    {
        private readonly IEmployedRepository _repository;

        public Employedservices(IEmployedRepository repository)
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

        public async Task CreateEmployedAsync(Employed employed)
        {
            // Puedes agregar validaciones o lógica adicional antes de crear el empleado
            await _repository.CreateEmployedAsync(employed);
        }

        public async Task UpdateEmployedAsync(Employed employed)
        {
            // Puedes agregar validaciones o lógica adicional antes de actualizar el empleado
             await _repository.UpdateEmployedAsync(employed);
        }

        public async Task SoftDeleteEmployedAsync(int id)
        {
            await _repository.SoftDeleteEmployedAsync(id);
        }
    }
}