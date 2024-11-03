using Microsoft.AspNetCore.Mvc;
using backend_proyecto.Services;
using backend_proyecto.model;
using backend_proyecto.DTOs;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    // GET: api/Project
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DTOProject>>> GetAllProjects()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        var dtoProjects = projects.Select(project => new DTOProject
        {
            Id = project.Id,
            Nombre = project.Nombre,
            Descripcion = project.Descripcion,
            FechaInicio = project.FechaInicio,
            FechaFin = project.FechaFin,
            IsDeleted = project.IsDeleted
        }).ToList();
        return Ok(dtoProjects);
    }

    // GET: api/Project/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<DTOProject>> GetProjectByIdAsync(int id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        var dtoProject = new DTOProject
        {
            Id = project.Id,
            Nombre = project.Nombre,
            Descripcion = project.Descripcion,
            FechaInicio = project.FechaInicio,
            FechaFin = project.FechaFin,
            IsDeleted = project.IsDeleted
        };
        return Ok(dtoProject);
    }

    // POST: api/Project
    [HttpPost]
    public async Task<IActionResult> CreateProjectAsync([FromBody] DTOProject projectDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var project = await _projectService.CreateProjectAsync(projectDTO.Nombre, projectDTO.Descripcion, projectDTO.FechaInicio, projectDTO.FechaFin);
        return Ok(project);
    }

    // PUT: api/Project/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProjectAsync(int id, DTOProject projectDTO)
    {
        if (id != projectDTO.Id)
        {
            return BadRequest();
        }
        var updatedProject = await _projectService.UpdateProjectAsync(projectDTO.Id, projectDTO.Nombre, projectDTO.Descripcion, projectDTO.FechaInicio, projectDTO.FechaFin);
        if (updatedProject == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    // DELETE: api/Project/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> SoftDeleteProjectAsync(int id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        await _projectService.SoftDeleteProjectAsync(id);
        return NoContent();
    }
}