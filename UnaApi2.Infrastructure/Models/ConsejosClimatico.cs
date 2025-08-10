using System;
using System.Collections.Generic;

namespace UnaApi2.Infrastructure.Models;

public partial class ConsejosClimatico
{
    public int ConsejoId { get; set; }

    public string Condicion { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public string? Nivel { get; set; }

    public int? LecturaId { get; set; }

    public virtual LecturasClimatica? Lectura { get; set; }
}
