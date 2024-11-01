// Controlador para Empleados
using backend_proyecto.model;
using Microsoft.AspNetCore.Mvc;
using backend_proyecto.Services;
using Microsoft.AspNetCore.Http;

[Route("api/[controller]")]
[ApiController]
public class EmployedController : ControllerBase
{
    private readonly IEmployedservices _employedService;

    public EmployedController(IEmployedservices employedService)
    {
        _employedService = employedService;
    }

    // GET: api/Employed
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllEmployedsAsync()
    {
        var employed = await _employedService.GetAllEmployedsAsync();
        return Ok(employed);
    }

    // GET: api/Employed/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateEmployedAsync(Employed employed)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _employedService.CreateEmployedAsync(employed);
        return CreatedAtAction(nameof(GetEmployedByIdAsync), new { id = employed.Id }, employed);
    }

    // PUT: api/Employed/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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