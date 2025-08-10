using System;
using System.ComponentModel.DataAnnotations;

namespace UnaApi2.Application.DTOs
{
    public class LecturasClimaticaCreateDto
    {
        public int LecturaId { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Temperatura { get; set; }
        public decimal Humedad { get; set; }
        public decimal? Presion { get; set; }
        public decimal? VelocidadViento { get; set; }
        public string? DireccionViento { get; set; }
        public decimal? Precipitacion { get; set; }
    }
}