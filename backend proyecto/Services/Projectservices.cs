using backend_proyecto.model;
using backend_proyecto.repositories;
using backend_proyecto.DTOs;

namespace backend_proyecto.services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            //_projectRepository = projectRepository;
            throw new NotImplementedException();
        }

        public async Task CreateProjectAsync(Project project)
        {
            //await _projectRepository.CreateProjectAsync(project);
            throw new NotImplementedException();
        }

        public Task CreateProjectAsync(DTOProject project)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            //return await _projectRepository.GetAllProjectsAsync();
            throw new NotImplementedException();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            //return await _projectRepository.GetProjectByIdAsync(id);
            throw new NotImplementedException();
        }

        public async Task SoftDeleteProjectAsync(int id)
        {
            throw new NotImplementedException();
            //await _projectRepository.SoftDeleteProjectAsync(id);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            throw new NotImplementedException();
            //await _projectRepository.UpdateProjectAsync(project);
        }

        public Task UpdateProjectAsync(DTOProject projectDTO)
        {
            throw new NotImplementedException();
        }
    }
}