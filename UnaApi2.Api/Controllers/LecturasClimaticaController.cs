using Microsoft.AspNetCore.Mvc;
using UnaApi2.Application.Contracts;
using UnaApi2.Application.DTOs;
using UnaApi2.Infrastructure.Exceptions;

namespace UnaApi2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturasClimaticaController : ControllerBase
    {
        private readonly ILecturasClimaticaService _lecturasclimaticaService;
        
        public LecturasClimaticaController(ILecturasClimaticaService lecturasclimaticaService)
        {
            _lecturasclimaticaService = lecturasclimaticaService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LecturasClimaticaReadDto>>> GetAll()
        {
            try
            {
                var result = await _lecturasclimaticaService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<LecturasClimaticaReadDto>> GetById(int id)
        {
            try
            {
                var result = await _lecturasclimaticaService.GetByIdAsync(id);
                if (result == null)
                    return NotFound($"LecturasClimatica con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (LecturasClimaticaNotFoundException)
            {
                return NotFound($"LecturasClimatica con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<LecturasClimaticaReadDto>> Create([FromBody] LecturasClimaticaCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _lecturasclimaticaService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = result.LecturaId }, result);
            }
            catch (LecturasClimaticaValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<LecturasClimaticaReadDto>> Update(int id, [FromBody] LecturasClimaticaUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _lecturasclimaticaService.UpdateAsync(id, updateDto);
                if (result == null)
                    return NotFound($"LecturasClimatica con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (LecturasClimaticaNotFoundException)
            {
                return NotFound($"LecturasClimatica con ID {id} no encontrado");
            }
            catch (LecturasClimaticaValidationException ex)
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
                var result = await _lecturasclimaticaService.DeleteAsync(id);
                if (!result)
                    return NotFound($"LecturasClimatica con ID {id} no encontrado");
                    
                return NoContent();
            }
            catch (LecturasClimaticaNotFoundException)
            {
                return NotFound($"LecturasClimatica con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}