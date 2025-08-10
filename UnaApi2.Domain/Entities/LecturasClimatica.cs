using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnaApi2.Domain.Entities
{
    public partial class LecturasClimatica
    {
        public int LecturaId { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Temperatura { get; set; }
        public decimal Humedad { get; set; }
        public decimal? Presion { get; set; }
        public decimal? VelocidadViento { get; set; }
        public string? DireccionViento { get; set; }
        public decimal? Precipitacion { get; set; }
        public virtual ICollection<AlertasMeteorologica> AlertasMeteorologicas { get; set; } = new List<AlertasMeteorologica>();
        public virtual ICollection<ConsejosClimatico> ConsejosClimaticos { get; set; } = new List<ConsejosClimatico>();
    }
}