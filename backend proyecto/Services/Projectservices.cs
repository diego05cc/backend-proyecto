using backend_proyecto.Repositories;
using backend_proyecto.model;
using System.Threading.Tasks;

namespace backend_proyecto.Services
{
    public class Projectservices : IProjectservices
    {
        private readonly IProjectRepository _repository;

        public Projectservices(IProjectRepository repository)
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

        public async Task<Project> CreateProjectAsync(string Nombre, string Descripcion, DateTime FechaInicio, DateTime FechaFin, bool IsDeleted)
        {
            var newProject = new Project
            {
                Nombre = Nombre,
                Descripcion = Descripcion,
                FechaInicio = FechaInicio,
                FechaFin = FechaFin,
                IsDeleted = IsDeleted // Inicializamos como no eliminado
            };
            await _repository.CreateProjectAsync(newProject);
            return newProject;
        }

        public async Task<Project> UpdateProjectAsync(int id, string Nombre, string Descripcion, DateTime FechaInicio, DateTime FechaFin, bool IsDeleted)
        {
            var projectToUpdate = await _repository.GetProjectByIdAsync(id);
            if (projectToUpdate != null)
            {
                projectToUpdate.Nombre = Nombre;
                projectToUpdate.Descripcion = Descripcion;
                projectToUpdate.FechaInicio = FechaInicio;
                projectToUpdate.FechaFin = FechaFin;
                projectToUpdate.IsDeleted = IsDeleted;
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