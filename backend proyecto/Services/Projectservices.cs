using backend_proyecto.model;
using backend_proyecto.repositories;

namespace backend_proyecto.services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task CreateProjectAsync(DTOProject project)
        {
            await _projectRepository.CreateProjectAsync(project);
        }

        public async Task<IEnumerable<DTOProject>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllProjectsAsync();
        }

        public async Task<DTOProject> GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetProjectByIdAsync(id);
        }

        public async Task SoftDeleteProjectAsync(int id)
        {
            await _projectRepository.SoftDeleteProjectAsync(id);
        }

        public async Task UpdateProjectAsync(DTOProject project)
        {
            await _projectRepository.UpdateProjectAsync(project);
        }
    }
}