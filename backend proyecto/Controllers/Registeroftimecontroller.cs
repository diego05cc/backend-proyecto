using backend_proyecto.model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class RegisteroftimesController : ControllerBase
{
    private readonly RegisteroftimeService _registeroftimeService;

    public RegisteroftimesController(RegisteroftimeService registeroftimeService)
    {
        _registeroftimeService = registeroftimeService;
    }

    // GET: api/Registeroftimes
    [HttpGet]
    public async Task<IActionResult> GetAllRegisteroftimesAsync()
    {
        var registeroftimes = await _registeroftimeService.GetAllRegisteroftimesAsync();
        return Ok(registeroftimes);
    }

    // GET: api/Registeroftimes/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRegisteroftimeByIdAsync(int id)
    {
        var registeroftime = await _registeroftimeService.GetRegisteroftimeByIdAsync(id);
        if (registeroftime == null)
        {
            return NotFound();
        }
        return Ok(registeroftime);
    }

    // POST: api/Registeroftimes
    [HttpPost]
    public async Task<IActionResult> CreateRegisteroftimeAsync(Registeroftime registeroftime)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdRegisteroftime = await _registeroftimeService.CreateRegisteroftimeAsync(registeroftime);
        return CreatedAtRoute("GetRegisteroftimeById", new { id = createdRegisteroftime.Id }, createdRegisteroftime);
    }

    // PUT: api/Registeroftimes/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRegisteroftimeAsync(int id, Registeroftime registeroftime)
    {
        if (id != registeroftime.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (await _registeroftimeService.GetRegisteroftimeByIdAsync(id) == null)
        {
            return NotFound();
        }

        await _registeroftimeService.UpdateRegisteroftimeAsync(registeroftime);

        return NoContent();
    }

    // DELETE: api/Registeroftimes/{id} (Soft Delete)
    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDeleteRegisteroftimeAsync(int id)
    {
        await _registeroftimeService.SoftDeleteRegisteroftimeAsync(id);
        return NoContent();
    }
}