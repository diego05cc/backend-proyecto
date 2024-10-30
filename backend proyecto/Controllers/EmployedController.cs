// Controlador para Empleados
using backend_proyecto.model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class EmployedController : ControllerBase
{
    private readonly EmployedService _employedService;

    public EmployedController(EmployedService employedService)
    {
        _employedService = employedService;
    }

    // GET: api/Employed
    [HttpGet]
    public async Task<IActionResult> GetAllEmployedsAsync()
    {
        var employed = await _employedService.GetAllEmployedsAsync();
        return Ok(employed);
    }

    // GET: api/Employed/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployedByIdAsync(int id)
    {
        var employed = await _employedService.GetEmployedByIdAsync(id);
        if (employed == null)
        {
            return NotFound();
        }
        return Ok(employed);
    }

    // POST: api/Employed
    [HttpPost]
    public async Task<IActionResult> CreateEmployedAsync(Employed employed)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdEmployed = await _employedService.CreateEmployedAsync(employed);
        return CreatedAtRoute("GetEmployedById", new { id = createdEmployed.Id }, createdEmployed);
    }

    // PUT: api/Employed/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployedAsync(int id, Employed employed)
    {
        if (id != employed.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (await _employedService.GetEmployedByIdAsync(id) == null)
        {
            return NotFound();
        }

        await _employedService.UpdateEmployedAsync(employed);

        return NoContent();
    }

    // DELETE: api/Employed/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDeleteEmployedAsync(int id)
    {
        var employed = await _employedService.SoftDeleteEmployedAsync(id);
        if (employed == null)
        {
            return NotFound();
        }
        return Ok(employed);
    }
}