using backend_proyecto.model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly TasksService _tasksService;

    public TasksController(TasksService tasksService)
    {
        _tasksService = tasksService;
    }

    // GET: api/Tasks
    [HttpGet]
    public async Task<IActionResult> GetAllTasksAsync()
    {
        var tasks = await _tasksService.GetAllTaskssAsync();
        return Ok(tasks);
    }

    // GET: api/Tasks/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskByIdAsync(int id)
    {
        var task = await _tasksService.GetTasksByIdAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    // POST: api/Tasks
    [HttpPost]
    public async Task<IActionResult> CreateTaskAsync(Tasks task)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdTask = await _tasksService.CreateTasksAsync(task);
        return CreatedAtRoute("GetTaskById", new { id = createdTask.Id }, createdTask);
    }

    // PUT: api/Tasks/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTaskAsync(int id, Tasks task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (await _tasksService.GetTasksByIdAsync(id) == null)
        {
            return NotFound();
        }

        await _tasksService.UpdateTasksAsync(task);

        return NoContent();
    }

    // DELETE: api/Tasks/{id} (Soft Delete)
    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDeleteTaskAsync(int id)
    {
        await _tasksService.SoftDeleteTasksAsync(id);
        return NoContent();
    }
}