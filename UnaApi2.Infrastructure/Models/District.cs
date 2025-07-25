using System;
using System.Collections.Generic;

namespace UnaApi2.Infrastructure.Models;

public partial class District
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int? MunicipalityId { get; set; }

    public double? Temperature { get; set; }

    public double? Humidity { get; set; }

    public string? Condition { get; set; }

    public virtual Municipality? Municipality { get; set; }
}
