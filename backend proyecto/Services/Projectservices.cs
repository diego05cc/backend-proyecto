using backend_proyecto.Repositories;
using backend_proyecto.model;
using System.Threading.Tasks;

namespace backend_proyecto.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Project>> GetAllProjectsAsync()
        {
            return _repository.GetAllProjectsAsync();
        }

        public Task<Project> GetProjectByIdAsync(int id)
        {
            return _repository.GetProjectByIdAsync(id);
        }

        public async Task<Project> CreateProjectAsync(string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            var newProject = new Project
            {
                Nombre = nombre,
                Descripcion = descripcion,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                IsDeleted = false // Inicializamos como no eliminado
            };
            await _repository.CreateProjectAsync(newProject);
            return newProject;
        }

        public async Task<Project> UpdateProjectAsync(int id, string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            var projectToUpdate = await _repository.GetProjectByIdAsync(id);
            if (projectToUpdate != null)
            {
                projectToUpdate.Nombre = nombre;
                projectToUpdate.Descripcion = descripcion;
                projectToUpdate.FechaInicio = fechaInicio;
                projectToUpdate.FechaFin = fechaFin;
                await _repository.UpdateProjectAsync(projectToUpdate);
            }
            return projectToUpdate;
        }

        public async Task<Project> SoftDeleteProjectAsync(int id)
        {
            var projectToDelete = await _repository.GetProjectByIdAsync(id);
            if (projectToDelete != null)
            {
                projectToDelete.IsDeleted = true;
                await _repository.UpdateProjectAsync(projectToDelete);
            }
            return projectToDelete;
        }
    }
}