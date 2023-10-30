using System;
using System.Collections.Generic;

namespace ABCSAC.Domain.Entities;

public partial class Empleado : BaseEntity
{
    
    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public int? IdAfp { get; set; }

    public int? IdCargo { get; set; }

    public decimal? Sueldo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Afp? Afp { get; set; }

    public virtual Cargo? Cargo { get; set; }
}
