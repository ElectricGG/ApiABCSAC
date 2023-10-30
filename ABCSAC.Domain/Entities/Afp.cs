using System;
using System.Collections.Generic;

namespace ABCSAC.Domain.Entities;

public partial class Afp : BaseEntity
{
    public string? Nombre { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
