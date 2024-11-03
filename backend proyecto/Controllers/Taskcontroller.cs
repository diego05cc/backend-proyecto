using Microsoft.AspNetCore.Mvc;
using backend_proyecto.Services;
using backend_proyecto.model;
using backend_proyecto.DTOs;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ITaskservices _tasksService;

    public TasksController(ITaskservices tasksService)
    {
        _tasksService = tasksService;
    }

    // GET: api/Tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DTOTasks>>> GetAllTasks()
    {
        var tasks = await _tasksService.GetAllTasksAsync();
        var dtoTasks = tasks.Select(t => new DTOTasks
        {
            Id = t.Id,
            Nombre = t.Nombre,
            Descripcion = t.Descripcion,
            ProyectoId = t.ProyectoId,
            IsDeleted = t.IsDeleted
        }).ToList();
        return Ok(dtoTasks);
    }

    // GET: api/Tasks/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<DTOTasks>> GetTaskByIdAsync(int id)
    {
        var task = await _tasksService.GetTaskByIdAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        var dtoTask = new DTOTasks
        {
            Id = task.Id,
            Nombre = task.Nombre,
            Descripcion = task.Descripcion,
            ProyectoId = task.ProyectoId,
            IsDeleted = task.IsDeleted
        };
        return Ok(dtoTask);
    }

    // POST: api/Tasks
    [HttpPost]
    public async Task<IActionResult> CreateTaskAsync([FromBody] DTOTasks taskDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var task = await _tasksService.CreateTaskAsync(taskDTO.Nombre, taskDTO.Descripcion, taskDTO.ProyectoId, taskDTO.IsDeleted);
        return Ok(task);
    }

    // PUT: api/Tasks/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTaskAsync(int id, DTOTasks taskDTO)
    {
        if (id != taskDTO.Id)
        {
            return BadRequest();
        }
        var updatedTask = await _tasksService.UpdateTaskAsync(taskDTO.Id, taskDTO.Nombre, taskDTO.Descripcion, taskDTO.ProyectoId, taskDTO.IsDeleted);
        if (updatedTask == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    // DELETE: api/Tasks/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> SoftDeleteTaskAsync(int id)
    {
        var task = await _tasksService.GetTaskByIdAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        await _tasksService.SoftDeleteTaskAsync(id);
        return NoContent();
    }
}