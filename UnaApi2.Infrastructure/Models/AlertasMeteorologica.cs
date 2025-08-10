using System;
using System.Collections.Generic;

namespace UnaApi2.Infrastructure.Models;

public partial class AlertasMeteorologica
{
    public int AlertaId { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string Tipo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Nivel { get; set; } = null!;

    public int? LecturaId { get; set; }

    public virtual LecturasClimatica? Lectura { get; set; }
}
