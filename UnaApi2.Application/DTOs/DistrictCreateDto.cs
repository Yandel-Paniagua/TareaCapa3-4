using System;
using System.ComponentModel.DataAnnotations;

namespace UnaApi2.Application.DTOs
{
    public class DistrictCreateDto
    {
        
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? MunicipalityId { get; set; }
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public string? Condition { get; set; }
    }
}