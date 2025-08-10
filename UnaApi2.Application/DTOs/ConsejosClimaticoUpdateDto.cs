using System;
using System.ComponentModel.DataAnnotations;

namespace UnaApi2.Application.DTOs
{
    public class ConsejosClimaticoUpdateDto
    {
        public int ConsejoId { get; set; }
        public string Condicion { get; set; }
        public string Mensaje { get; set; }
        public string? Nivel { get; set; }
        public int? LecturaId { get; set; }
    }
}