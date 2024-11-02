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
        return CreatedAtAction(nameof(GetEmployedByIdAsync), new { id = employed.Employed_Id }, employed);
    }

    // PUT: api/Employed/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateEmployedAsync(int id, Employed employed)
    {
        if (id != employed.Employed_Id)
        {
            return BadRequest();
        }
        var existingEmployed = await _employedService.GetEmployedByIdAsync(id);
        if (existingEmployed == null)
        {
            return NoContent();
        }

        await _employedService.UpdateEmployedAsync(employed);

        return NoContent();
    }

    // DELETE: api/Employed/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> SoftDeleteEmployedAsync(int id)
    {
        var Employed = await _employedService.GetEmployedByIdAsync(id);
        if (Employed == null)
        {
            return NotFound();
        }
        await _employedService.SoftDeleteEmployedAsync(id);
        return NoContent();
    }
}