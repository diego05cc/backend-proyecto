// Controlador para Empleados
using Microsoft.AspNetCore.Mvc;
using backend_proyecto.Services;
using backend_proyecto.model;
using Microsoft.AspNetCore.Http;
using backend_proyecto.model;
using backend_proyecto.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EmployedController : Controller
{
    private readonly IEmployedservices _employedService;

    public EmployedController(IEmployedservices employedService)
    {
        _employedService = employedService;
    }

    // GET: api/Employed
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DTOEmployed>>> GetAllEmployeds()
    {
        var Employeds = await _employedService.GetAllEmployedsAsync();
        var DTOemployed = Employeds.Select(employed => new DTOEmployed
        {
            Employed_Id = employed.Employed_Id,
            Nombre = employed.Nombre,
            Apellido = employed.Apellido,
            Departamento = employed.Departamento,
            Cargo = employed.Cargo,
            IsDeleted = employed.IsDeleted,
            FechaIngreso = employed.FechaIngreso,
        }).ToList();
        return Ok(DTOemployed);
    }

    // GET: api/Employed/{id}
    [HttpGet("{id}")]

    public async Task<ActionResult<DTOEmployed>> GetEmployedByIdAsync(int id)
    {
        var employed = await _employedService.GetEmployedByIdAsync(id);
        if(employed == null)
        {
            return NotFound();
        }
        var DTOemployed = new DTOEmployed
        {
            Employed_Id = employed.Employed_Id,
            Nombre = employed.Nombre,
            Apellido = employed.Apellido,
            Departamento = employed.Departamento,
            Cargo = employed.Cargo,
            IsDeleted = employed.IsDeleted,
            FechaIngreso = employed.FechaIngreso,
        };
        return Ok(DTOemployed);
    }

    // POST: api/Employed
    [HttpPost]

    public async Task<IActionResult> CreateEmployedAsync([FromBody]DTOEmployed employedDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var employed = await _employedService.CreateEmployedAsync(employedDTO.Nombre, employedDTO.Apellido, employedDTO.Departamento, employedDTO.Cargo, employedDTO.IsDeleted, employedDTO.FechaIngreso);
       return Ok(employed);
    }

    // PUT: api/Employed/{id}
    [HttpPut("{id}")]
    
    public async Task<IActionResult> UpdateEmployedAsync(int id, DTOEmployed employedDTO)
    {
        if (id != employedDTO.Employed_Id)
        {
            return BadRequest();
        }
        var UpdateEmployed = await _employedService.UpdateEmployedAsync(employedDTO.Employed_Id, employedDTO.Nombre, employedDTO.Apellido, employedDTO.Departamento, employedDTO.Cargo, employedDTO.IsDeleted, employedDTO.FechaIngreso);
        if (UpdateEmployed == null)
        {
            return NotFound();
        }


        return NoContent();
    }

    // DELETE: api/Employed/{id}
    [HttpDelete("{id}")]
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