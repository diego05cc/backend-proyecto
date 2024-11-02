using backend_proyecto.model;
using backend_proyecto.services;
using Microsoft.AspNetCore.Mvc;

namespace backend_proyecto.controllers
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Employedproject>>> GetAllEmployedProjects()
        {
            var employedProjects = await _employedProjectService.GetAllEmployedProjectAsync();
            return Ok(employedProjects);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employedproject>> GetEmployedProjectById(int id)
        {
            var employedProject = await _employedProjectService.GetEmployedProjectByIdAsync(id);
            if (employedProject == null)
            {
                return NotFound();
            }
            return Ok(employedProject);
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employedproject>> CreateEmployedProject(Employedproject employedProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _employedProjectService.CreateEmployedProjectAsync(employedProject);
            return CreatedAtAction("GetEmployedProjectById", new { id = employedProject.EmpleadoId }, employedProject);
        }

     
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEmployedProject(int id, Employedproject employedProject)
        {
            if (id != employedProject.EmpleadoId)
            {
                return BadRequest();
            }

            await _employedProjectService.UpdateEmployedProjectAsync(employedProject);
            return NoContent();
        }

        /// <summary>
        /// Elimina (soft delete) una asignación de proyecto.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteEmployedProject(int id)
        {
            await _employedProjectService.SoftDeleteEmployedProjectAsync(id);
            return NoContent();
        }
    }
}