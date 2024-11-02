
using backend_proyecto.Repositories;
using backend_proyecto.model;
using System.Threading.Tasks;



namespace backend_proyecto.Services
{
    public interface IEmployedservices
    {
        Task<List<Employed>> GetAllEmployedsAsync();
        Task<Employed> GetEmployedByIdAsync(int Employed_Id);
        Task<Employed> CreateEmployedAsync(string Nombre, string Apellido, string Departamento, string Cargo, bool IsDeleted, DateTime FechaIngreso);
        Task<Employed> UpdateEmployedAsync(int Employed_Id,string Nombre, string Apellido, string Departamento, string Cargo, bool IsDeleted, DateTime FechaIngreso);

        Task<Employed> SoftDeleteEmployedAsync(int Employed_Id);
    }
}


