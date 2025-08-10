using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnaApi2.Application.DTOs
{
    public class DashboardDto
    {
        /// <summary>
        /// Clima actual en tiempo real.
        /// </summary>
        /// 
        public LecturasClimaticaReadDto Current { get; set; }

        /// <summary>
        /// Datos por hora para gráficas.
        /// </summary>
        public List<LecturasClimaticaReadDto> HourlyData { get; set; }

        /// <summary>
        /// Alertas meteorológicas vigentes.
        /// </summary>
        public List<AlertasMeteorologicaReadDto> ActiveAlerts { get; set; }

        /// <summary>
        /// Consejos relacionados con el clima actual.
        /// </summary>
        public List<ConsejosClimaticoReadDto> Advice { get; set; }

        /// <summary>
        /// Fecha y hora de la última actualización de datos.
        /// </summary>
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }

  
}
