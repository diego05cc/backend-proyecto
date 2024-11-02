using backend_proyecto.model;
using backend_proyecto.services;
using Microsoft.AspNetCore.Mvc;

namespace backend_proyecto.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteroftimeController : ControllerBase
    {
        private readonly IRegisteroftimeService _registeroftimeService;

        public RegisteroftimeController(IRegisteroftimeService registeroftimeService)
        {
            _registeroftimeService = registeroftimeService;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DTORegisteroftime>>> GetAllRegisteroftimes()
        {
            var registeroftimes = await _registeroftimeService.GetAllRegisteroftimesAsync();
            return Ok(registeroftimes);
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DTORegisteroftime>> GetRegisteroftimeById(int id)
        {
            var registeroftime = await _registeroftimeService.GetRegisteroftimeByIdAsync(id);
            if (registeroftime == null)
            {
                return NotFound();
            }
            return Ok(registeroftime);
        }

     
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DTORegisteroftime>> CreateRegisteroftime(DTORegisteroftime registeroftime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _registeroftimeService.CreateRegisteroftimeAsync(registeroftime);
            return CreatedAtAction("GetRegisteroftimeById", new { id = registeroftime.Id }, registeroftime);
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRegisteroftime(int id, DTORegisteroftime registeroftime)
        {
            if (id != registeroftime.Id)
            {
                return BadRequest();
            }

            await _registeroftimeService.UpdateRegisteroftimeAsync(registeroftime);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteRegisteroftime(int id)
        {
            await _registeroftimeService.SoftDeleteRegisteroftimeAsync(id);
            return NoContent();
        }
    }
}