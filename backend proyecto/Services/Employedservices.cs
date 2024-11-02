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

        public Task<List<Employed>> GetAllEmployedsAsync()
        {
            return  _repository.GetAllEmployedsAsync();
        }

        public Task<Employed> GetEmployedByIdAsync(int employed_Id)
        {
            return _repository.GetEmployedByIdAsync(employed_Id);
        }

        public async Task<Employed> CreateEmployedAsync( string Nombre, string Apellido, string Departamento, string Cargo, bool IsDeleted, DateTime FechaIngreso)
        {
            var newEmployed = new Employed
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Departamento = Departamento,
                Cargo = Cargo,
                IsDeleted = IsDeleted,
                FechaIngreso = FechaIngreso

            };
            await _repository.CreateEmployedAsync(newEmployed);
            return newEmployed;
        }

        public async Task<Employed> UpdateEmployedAsync(int Employed_Id, string Nombre, string Apellido, string Departamento, string Cargo, bool IsDeleted, DateTime FechaIngreso)
        {
            // Puedes agregar validaciones o lógica adicional antes de actualizar el empleado
            var EmployedtoUpdate = await _repository.GetEmployedByIdAsync(Employed_Id);
            if(EmployedtoUpdate != null)
            {
                EmployedtoUpdate.Nombre = Nombre;
                EmployedtoUpdate.Apellido = Apellido;
                EmployedtoUpdate.Departamento = Departamento;
                EmployedtoUpdate.Cargo = Cargo;
                EmployedtoUpdate.IsDeleted = IsDeleted;
                EmployedtoUpdate.FechaIngreso=FechaIngreso;
                await _repository.UpdateEmployedAsync(EmployedtoUpdate);
            }
            return EmployedtoUpdate;
        }

        public async Task<Employed> SoftDeleteEmployedAsync(int Employed_Id)
        {
            var EmployedtoDeleted = await _repository.GetEmployedByIdAsync(Employed_Id);
            if(EmployedtoDeleted != null)
            {
                await _repository.SoftDeleteEmployedAsync(EmployedtoDeleted);
            }
            return EmployedtoDeleted;
            
        }
    }
}