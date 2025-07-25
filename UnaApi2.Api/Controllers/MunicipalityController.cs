using Microsoft.AspNetCore.Mvc;
using UnaApi2.Application.Contracts;
using UnaApi2.Application.DTOs;
using UnaApi2.Infrastructure.Exceptions;

namespace UnaApi2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipalityController : ControllerBase
    {
        private readonly IMunicipalityService _municipalityService;
        
        public MunicipalityController(IMunicipalityService municipalityService)
        {
            _municipalityService = municipalityService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MunicipalityReadDto>>> GetAll()
        {
            try
            {
                var result = await _municipalityService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<MunicipalityReadDto>> GetById(int id)
        {
            try
            {
                var result = await _municipalityService.GetByIdAsync(id);
                if (result == null)
                    return NotFound($"Municipality con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (MunicipalityNotFoundException)
            {
                return NotFound($"Municipality con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<MunicipalityReadDto>> Create([FromBody] MunicipalityCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _municipalityService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (MunicipalityValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<MunicipalityReadDto>> Update(int id, [FromBody] MunicipalityUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _municipalityService.UpdateAsync(id, updateDto);
                if (result == null)
                    return NotFound($"Municipality con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (MunicipalityNotFoundException)
            {
                return NotFound($"Municipality con ID {id} no encontrado");
            }
            catch (MunicipalityValidationException ex)
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
                var result = await _municipalityService.DeleteAsync(id);
                if (!result)
                    return NotFound($"Municipality con ID {id} no encontrado");
                    
                return NoContent();
            }
            catch (MunicipalityNotFoundException)
            {
                return NotFound($"Municipality con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}