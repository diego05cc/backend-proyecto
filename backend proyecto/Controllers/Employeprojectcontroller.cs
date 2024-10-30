using backend_proyecto.model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class EmployedprojectsController : ControllerBase
{
    private readonly EmployedprojectService _employedprojectService;

    public EmployedprojectsController(EmployedprojectService employedprojectService)
    {
        _employedprojectService = employedprojectService;
    }

    // GET: api/Employedprojects
    [HttpGet]
    public async Task<IActionResult> GetAllEmployedprojectsAsync()
    {
        var employedprojects = await _employedprojectService.GetAllEmployedprojectsAsync();
        return Ok(employedprojects);
    }

    // GET: api/Employedprojects/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployedprojectByIdAsync(int id)
    {
        var employedproject = await _employedprojectService.GetEmployedprojectByIdAsync(id);
        if (employedproject == null)
        {
            return NotFound();
        }
        return Ok(employedproject);
    }

    // POST: api/Employedprojects
    [HttpPost]
    public async Task<IActionResult> CreateEmployedprojectAsync(Employedproject employedproject)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdEmployedproject = await _employedprojectService.CreateEmployedprojectAsync(employedproject);
        return CreatedAtRoute("GetEmployedprojectById", new { id = createdEmployedproject.EmpleadoId }, createdEmployedproject);
    }

    // PUT: api/Employedprojects/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployedprojectAsync(int id, Employedproject employedproject)
    {
        if (id != employedproject.EmpleadoId)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (await _employedprojectService.GetEmployedprojectByIdAsync(id) == null)
        {
            return NotFound();
        }

        await _employedprojectService.UpdateEmployedprojectAsync(employedproject);

        return NoContent();
    }

    // DELETE: api/Employedprojects/{id} (Soft Delete)
    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDeleteEmployedprojectAsync(int id)
    {
        await _employedprojectService.SoftDeleteEmployedprojectAsync(id);
        return NoContent();
    }
}