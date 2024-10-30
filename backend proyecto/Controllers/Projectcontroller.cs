using backend_proyecto.model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectService _projectService;

    public ProjectsController(ProjectService projectService)
    {
        _projectService = projectService;
    }

    // GET: api/Projects
    [HttpGet]
    public async Task<IActionResult> GetAllProjectsAsync()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        return Ok(projects);
    }

    // GET: api/Projects/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectByIdAsync(int id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    // POST: api/Projects
    [HttpPost]
    public async Task<IActionResult> CreateProjectAsync(Project project)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdProject = await _projectService.CreateProjectAsync(project);
        return CreatedAtRoute("GetProjectById", new { id = createdProject.Id }, createdProject);
    }

    // PUT: api/Projects/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProjectAsync(int id, Project project)
    {
        if (id != project.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (await _projectService.GetProjectByIdAsync(id) == null)
        {
            return NotFound();
        }

        await _projectService.UpdateProjectAsync(project);

        return NoContent();
    }

    // DELETE: api/Projects/{id} (Soft Delete)
    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDeleteProjectAsync(int id)
    {
        await _projectService.SoftDeleteProjectAsync(id);
        return NoContent();
    }
}