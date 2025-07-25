using Microsoft.AspNetCore.Mvc;
using UnaApi2.Application.Contracts;
using UnaApi2.Application.DTOs;
using UnaApi2.Infrastructure.Exceptions;

namespace UnaApi2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;
        
        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistrictReadDto>>> GetAll()
        {
            try
            {
                var result = await _districtService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<DistrictReadDto>> GetById(int id)
        {
            try
            {
                var result = await _districtService.GetByIdAsync(id);
                if (result == null)
                    return NotFound($"District con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (DistrictNotFoundException)
            {
                return NotFound($"District con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<DistrictReadDto>> Create([FromBody] DistrictCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _districtService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (DistrictValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<DistrictReadDto>> Update(int id, [FromBody] DistrictUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _districtService.UpdateAsync(id, updateDto);
                if (result == null)
                    return NotFound($"District con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (DistrictNotFoundException)
            {
                return NotFound($"District con ID {id} no encontrado");
            }
            catch (DistrictValidationException ex)
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
                var result = await _districtService.DeleteAsync(id);
                if (!result)
                    return NotFound($"District con ID {id} no encontrado");
                    
                return NoContent();
            }
            catch (DistrictNotFoundException)
            {
                return NotFound($"District con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}