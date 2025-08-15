using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
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
                using var client = new HttpClient();
                string url = $"https://api.openweathermap.org/data/2.5/weather?" +
                             $"lat=18.47186&lon=-69.89232&units=metric&lang=es&appid=eccaeac1c8f624eae265721c69e3b733";



                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, "Error al obtener datos del clima");
                var contenido = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(contenido);

                var dto = new LecturasClimaticaCreateDto
                {
                    LecturaId = 0, // Si lo guardas en BD puedes asignarlo allí
                    FechaHora = DateTimeOffset.FromUnixTimeSeconds((long)json["dt"]).DateTime,
                    Temperatura = (decimal)json["main"]["temp"], // Kelvin a °C
                    Humedad = (decimal)json["main"]["humidity"],
                    Presion = (decimal?)json["main"]["pressure"],
                    VelocidadViento = (decimal?)json["wind"]?["speed"],
                    DireccionViento = json["wind"]?["deg"] != null ? ConvertirDireccion((int)json["wind"]["deg"]) : null,
                    Precipitacion = json["rain"]?["1h"] != null ? (decimal?)json["rain"]["1h"] : null
                };
                var current = await _lecturasclimaticaService.GetLastReadingAsync();
                if (dto != null)
                {
                    if (dto.Temperatura != current.Temperatura || dto.Humedad != current.Humedad || dto.Presion != current.Presion)
                    {
                        await _lecturasclimaticaService.CreateAsync(dto);
                    }

                }

                var DashboardDto = new DashboardDto();
                DashboardDto.Current = current;
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

        string ConvertirDireccion(int grados)
        {
            string[] direcciones = { "N", "NE", "E", "SE", "S", "SO", "O", "NO", "N" };
            return direcciones[(int)Math.Round(((double)grados % 360) / 45)];
        }

    }
}
