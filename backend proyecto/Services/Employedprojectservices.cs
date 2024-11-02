using backend_proyecto.model;
using backend_proyecto.repositories;

namespace backend_proyecto.services
{
    public class EmployedProjectService : IEmployedProjectService
    {
        private readonly IEmployedProjectRepository _employedProjectRepository;

        public EmployedProjectService(IEmployedProjectRepository employedProjectRepository)
        {
            _employedProjectRepository = employedProjectRepository;
        }

        public async Task CreateEmployedProjectAsync(Employedproject employedProject)
        {
            await _employedProjectRepository.CreateEmployedProjectAsync(employedProject);
        }

        public async Task<IEnumerable<Employedproject>> GetAllEmployedProjectAsync()
        {
            return await _employedProjectRepository.GetAllEmployedProjectAsync();
        }

        public async Task<Employedproject> GetEmployedProjectByIdAsync(int id)
        {
            return await _employedProjectRepository.GetEmployedProjectByIdAsync(id);
        }

        public async Task SoftDeleteEmployedProjectAsync(int id)
        {
            await _employedProjectRepository.SoftDeleteEmployedProjectAsync(id);
        }
        public async Task UpdateEmployedProjectAsync(Employedproject employedproject)
        {
            await _employedProjectRepository.UpdateEmployedProjectAsync(employedproject);
        }
    }
}