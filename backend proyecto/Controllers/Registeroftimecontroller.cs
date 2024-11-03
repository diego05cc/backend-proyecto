using Microsoft.AspNetCore.Mvc;
using backend_proyecto.Services;
using backend_proyecto.model;
using backend_proyecto.DTOs;

[Route("api/[controller]")]
[ApiController]
public class RegisteroftimeController : ControllerBase
{
    private readonly IRegisteroftimeservices _registeroftimeService;

    public RegisteroftimeController(IRegisteroftimeservices registeroftimeService)
    {
        _registeroftimeService = registeroftimeService;
    }

    // GET: api/Registeroftime
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DTORegisteroftime>>> GetAllRegisteroftimes()
    {
        var registeroftimes = await _registeroftimeService.GetAllRegisteroftimesAsync();
        var dtoRegisteroftimes = registeroftimes.Select(r => new DTORegisteroftime
        {
            Id = r.Id,
            EmpleadoId = r.EmpleadoId,
            TareaId = r.TareaId,
            Fecha = r.Fecha,
            HoraInicio = r.HoraInicio,
            HoraFin = r.HoraFin,
            Descripcion = r.Descripcion,
            IsDeleted = r.IsDeleted
        }).ToList();
        return Ok(dtoRegisteroftimes);
    }

    // GET: api/Registeroftime/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<DTORegisteroftime>> GetRegisteroftimeByIdAsync(int id)
    {
        var registeroftime = await _registeroftimeService.GetRegisteroftimeByIdAsync(id);
        if (registeroftime == null)
        {
            return NotFound();
        }
        var dtoRegisteroftime = new DTORegisteroftime
        {
            Id = registeroftime.Id,
            EmpleadoId = registeroftime.EmpleadoId,
            TareaId = registeroftime.TareaId,
            Fecha = registeroftime.Fecha,
            HoraInicio = registeroftime.HoraInicio,
            HoraFin = registeroftime.HoraFin,
            Descripcion = registeroftime.Descripcion,
            IsDeleted = registeroftime.IsDeleted
        };
        return Ok(dtoRegisteroftime);
    }

    // POST: api/Registeroftime
    [HttpPost]
    public async Task<IActionResult> CreateRegisteroftimeAsync([FromBody] DTORegisteroftime registeroftimeDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var registeroftime = await _registeroftimeService.CreateRegisteroftimeAsync(registeroftimeDTO.EmpleadoId, registeroftimeDTO.TareaId, registeroftimeDTO.Fecha, registeroftimeDTO.HoraInicio, registeroftimeDTO.HoraFin, registeroftimeDTO.Descripcion, registeroftimeDTO.IsDeleted);
        return Ok(registeroftime);
    }

    // PUT: api/Registeroftime/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRegisteroftimeAsync(int id, DTORegisteroftime registeroftimeDTO)
    {
        if (id != registeroftimeDTO.Id)
        {
            return BadRequest();
        }
        var updatedRegisteroftime = await _registeroftimeService.UpdateRegisteroftimeAsync(registeroftimeDTO.Id, registeroftimeDTO.EmpleadoId, registeroftimeDTO.TareaId, registeroftimeDTO.Fecha, registeroftimeDTO.HoraInicio, registeroftimeDTO.HoraFin, registeroftimeDTO.Descripcion,registeroftimeDTO.IsDeleted);
        if (updatedRegisteroftime == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}

    // DELETE