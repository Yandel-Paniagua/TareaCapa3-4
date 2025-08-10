using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnaApi2.Domain.Entities
{
    public partial class ConsejosClimatico
    {
        public int ConsejoId { get; set; }
        public string Condicion { get; set; }
        public string Mensaje { get; set; }
        public string? Nivel { get; set; }
        public int? LecturaId { get; set; }
        public virtual LecturasClimatica? Lectura { get; set; }
    }
}