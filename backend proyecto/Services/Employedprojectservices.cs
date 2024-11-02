using backend_proyecto.model;
using backend_proyecto.repositories;
using backend_proyecto.Repositories;

namespace backend_proyecto.services
{
    public class EmployedProjectService : IEmployedProjectService
    {
        private readonly IEmployedProjectRepository _employedProjectRepository;

        public EmployedProjectService(IEmployedProjectRepository employedProjectRepository)
        {
            _employedProjectRepository = employedProjectRepository;
        }

        public async Task<Employedproject> CreateEmployedProjectAsync(int EmpleadoId, int ProyectoId, bool IsDeleted)
        {
            var newEmployedProject = new Employedproject
            {
                EmpleadoId = EmpleadoId,
                ProyectoId = ProyectoId,
                IsDeleted = IsDeleted
            };
            await _employedProjectRepository.CreateEmployedProjectAsync(newEmployedProject);
            return newEmployedProject;
        }

        public Task<List<Employedproject>> GetAllEmployedProjectAsync()
        {
            return _employedProjectRepository.GetAllEmployedProjectAsync();
        }

        public async Task<Employedproject> GetEmployedProjectByIdAsync(int Id)
        {
            return await _employedProjectRepository.GetEmployedProjectByIdAsync(Id);
        }

        public async Task<Employedproject> SoftDeleteEmployedProjectAsync(int Id)
        {
            var EmployedprojecttoDeleted = await _employedProjectRepository.GetEmployedProjectByIdAsync(Id);
            if (EmployedprojecttoDeleted != null)
            {
                await _employedProjectRepository.SoftDeleteEmployedProjectAsync(EmployedprojecttoDeleted);
            }
            return EmployedprojecttoDeleted;
        }
        public async Task<Employedproject> UpdateEmployedProjectAsync(int Id, int EmpleadoId, int ProyectoId, bool IsDeleted)
        {
            var EPtoUpdate = await _employedProjectRepository.GetEmployedProjectByIdAsync(Id);
            if (EPtoUpdate != null)
            {
                EPtoUpdate.Id = Id;
                EPtoUpdate.EmpleadoId = EmpleadoId;
                EPtoUpdate.ProyectoId = ProyectoId;
                EPtoUpdate.IsDeleted = IsDeleted;
                await _employedProjectRepository.UpdateEmployedProjectAsync(EPtoUpdate);
            }
            return EPtoUpdate;
        }
    }
}