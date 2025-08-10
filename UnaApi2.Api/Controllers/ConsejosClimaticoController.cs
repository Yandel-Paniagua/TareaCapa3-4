using Microsoft.AspNetCore.Mvc;
using UnaApi2.Application.Contracts;
using UnaApi2.Application.DTOs;
using UnaApi2.Infrastructure.Exceptions;

namespace UnaApi2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsejosClimaticoController : ControllerBase
    {
        private readonly IConsejosClimaticoService _consejosclimaticoService;
        
        public ConsejosClimaticoController(IConsejosClimaticoService consejosclimaticoService)
        {
            _consejosclimaticoService = consejosclimaticoService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsejosClimaticoReadDto>>> GetAll()
        {
            try
            {
                var result = await _consejosclimaticoService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsejosClimaticoReadDto>> GetById(int id)
        {
            try
            {
                var result = await _consejosclimaticoService.GetByIdAsync(id);
                if (result == null)
                    return NotFound($"ConsejosClimatico con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (ConsejosClimaticoNotFoundException)
            {
                return NotFound($"ConsejosClimatico con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<ConsejosClimaticoReadDto>> Create([FromBody] ConsejosClimaticoCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _consejosclimaticoService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = result.ConsejoId}, result);
            }
            catch (ConsejosClimaticoValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ConsejosClimaticoReadDto>> Update(int id, [FromBody] ConsejosClimaticoUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _consejosclimaticoService.UpdateAsync(id, updateDto);
                if (result == null)
                    return NotFound($"ConsejosClimatico con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (ConsejosClimaticoNotFoundException)
            {
                return NotFound($"ConsejosClimatico con ID {id} no encontrado");
            }
            catch (ConsejosClimaticoValidationException ex)
            {
                return BadRequest(ex.Message);  
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _consejosclimaticoService.DeleteAsync(id);
                if (!result)
                    return NotFound($"ConsejosClimatico con ID {id} no encontrado");
                    
                return NoContent();
            }
            catch (ConsejosClimaticoNotFoundException)
            {
                return NotFound($"ConsejosClimatico con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}