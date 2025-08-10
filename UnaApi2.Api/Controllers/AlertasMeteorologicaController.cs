using Microsoft.AspNetCore.Mvc;
using UnaApi2.Application.Contracts;
using UnaApi2.Application.DTOs;
using UnaApi2.Infrastructure.Exceptions;

namespace UnaApi2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertasMeteorologicaController : ControllerBase
    {
        private readonly IAlertasMeteorologicaService _alertasmeteorologicaService;
        
        public AlertasMeteorologicaController(IAlertasMeteorologicaService alertasmeteorologicaService)
        {
            _alertasmeteorologicaService = alertasmeteorologicaService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlertasMeteorologicaReadDto>>> GetAll()
        {
            try
            {
                var result = await _alertasmeteorologicaService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<AlertasMeteorologicaReadDto>> GetById(int id)
        {
            try
            {
                var result = await _alertasmeteorologicaService.GetByIdAsync(id);
                if (result == null)
                    return NotFound($"AlertasMeteorologica con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (AlertasMeteorologicaNotFoundException)
            {
                return NotFound($"AlertasMeteorologica con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<AlertasMeteorologicaReadDto>> Create([FromBody] AlertasMeteorologicaCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _alertasmeteorologicaService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = result.AlertaId }, result);
            }
            catch (AlertasMeteorologicaValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<AlertasMeteorologicaReadDto>> Update(int id, [FromBody] AlertasMeteorologicaUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _alertasmeteorologicaService.UpdateAsync(id, updateDto);
                if (result == null)
                    return NotFound($"AlertasMeteorologica con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (AlertasMeteorologicaNotFoundException)
            {
                return NotFound($"AlertasMeteorologica con ID {id} no encontrado");
            }
            catch (AlertasMeteorologicaValidationException ex)
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
                var result = await _alertasmeteorologicaService.DeleteAsync(id);
                if (!result)
                    return NotFound($"AlertasMeteorologica con ID {id} no encontrado");
                    
                return NoContent();
            }
            catch (AlertasMeteorologicaNotFoundException)
            {
                return NotFound($"AlertasMeteorologica con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}