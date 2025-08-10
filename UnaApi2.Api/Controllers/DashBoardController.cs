using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnaApi2.Application.Contracts;
using UnaApi2.Application.DTOs;

namespace UnaApi2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IAlertasMeteorologicaService _alertasmeteorologicaService;
        private readonly IConsejosClimaticoService _consejosclimaticoService;
        private readonly ILecturasClimaticaService _lecturasclimaticaService;

        public DashBoardController(IAlertasMeteorologicaService alertasmeteorologicaService, IConsejosClimaticoService consejosclimaticoService, ILecturasClimaticaService lecturasclimaticaService)
        {
            _alertasmeteorologicaService = alertasmeteorologicaService;
            _consejosclimaticoService = consejosclimaticoService;
            _lecturasclimaticaService = lecturasclimaticaService;
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetDashboardSummary()
        {
            try
            {
                //var alertasCount = (await _alertasmeteorologicaService.GetAllAsync()).Count();
                //var consejosCount = (await _consejosclimaticoService.GetAllAsync()).Count();
                //var lecturasCount = (await _lecturasclimaticaService.GetAllAsync()).Count();
                //var summary = new
                //{
                //    AlertasMeteorologicaCount = alertasCount,
                //    ConsejosClimaticoCount = consejosCount,
                //    LecturasClimaticaCount = lecturasCount
                //};
                var DashboardDto = new DashboardDto();
                DashboardDto.Current = await _lecturasclimaticaService.GetLastReadingAsync();
                DashboardDto.ActiveAlerts = await _alertasmeteorologicaService.GetActiveAlertsAsync();
                DashboardDto.Advice = await _consejosclimaticoService.GetAllActiveConsejosAsync();
                DashboardDto.HourlyData = await _lecturasclimaticaService.GetAllActiveLecturasAsync();
                return Ok(DashboardDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

    }
}
