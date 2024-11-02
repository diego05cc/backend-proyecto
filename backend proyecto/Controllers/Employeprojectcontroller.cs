using backend_proyecto.model;
using backend_proyecto.services;
using Microsoft.AspNetCore.Mvc;
using backend_proyecto.DTOs;

namespace backend_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployedProjectController : ControllerBase
    {
        private readonly IEmployedProjectService _employedProjectService;

        public EmployedProjectController(IEmployedProjectService employedProjectService)
        {
            _employedProjectService = employedProjectService;
        }


        [HttpGet]
        public async Task<ActionResult<List<DTOEmployedproject>>> GetAllEmployedProjects()
        {
            var employedProjects = await _employedProjectService.GetAllEmployedProjectAsync();
            var employedProjectsDto = employedProjects.ConvertAll(EP => new DTOEmployedproject
            {
                Id = EP.Id,
                EmpleadoId = EP.EmpleadoId,
                ProyectoId = EP.ProyectoId,
                IsDeleted = EP.IsDeleted
            });
            return Ok(employedProjects);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DTOEmployedproject>> GetEmployedProjectById(int id)
        {
            var employedProject = await _employedProjectService.GetEmployedProjectByIdAsync(id);
            if (employedProject == null)
            {
                return NotFound();
            }
            var EPDTO = new DTOEmployedproject
            {
                Id = employedProject.Id,
                EmpleadoId = employedProject.EmpleadoId,
                ProyectoId = employedProject.ProyectoId,
                IsDeleted = employedProject.IsDeleted
            };
            return Ok(employedProject);
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployedProject([FromBody] DTOEmployedproject employedProjectDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var EP = await _employedProjectService.CreateEmployedProjectAsync(employedProjectDTO.EmpleadoId, employedProjectDTO.ProyectoId, employedProjectDTO.IsDeleted);

            return Ok(EP);
        }


        [HttpPut("{id}")] 
        public async Task<IActionResult> UpdateEmployedProject(int id,[FromBody] DTOEmployedproject employedProjectDTO)
        {
            if (id != employedProjectDTO.Id)
            {
                return BadRequest();
            }
            var EPUpdate = await _employedProjectService.UpdateEmployedProjectAsync(employedProjectDTO.Id, employedProjectDTO.EmpleadoId, employedProjectDTO.ProyectoId, employedProjectDTO.IsDeleted);
            if (EPUpdate == null)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Elimina (soft delete) una asignación de proyecto.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteEmployedProject(int id)
        {
            var EPDeleted = await _employedProjectService.SoftDeleteEmployedProjectAsync(id);
            if (EPDeleted == null)
                return NotFound();

            return NoContent();
        }
    }
}