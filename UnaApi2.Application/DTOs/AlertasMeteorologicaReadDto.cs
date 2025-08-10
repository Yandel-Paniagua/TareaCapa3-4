using System;

namespace UnaApi2.Application.DTOs
{
    public class AlertasMeteorologicaReadDto
    {
        public int AlertaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Tipo { get; set; }
        public string? Descripcion { get; set; }
        public string Nivel { get; set; }
        public int? LecturaId { get; set; }
    }
}