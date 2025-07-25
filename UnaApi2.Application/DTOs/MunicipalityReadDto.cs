using System;

namespace UnaApi2.Application.DTOs
{
    public class MunicipalityReadDto
    {
        public int Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool? IsActive { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public string? Condition { get; set; }
    }
}