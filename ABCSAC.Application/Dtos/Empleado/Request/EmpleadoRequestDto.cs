using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCSAC.Application.Dtos.Empleado.Request
{
    public class EmpleadoRequestDto
    {
        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaIngreso { get; set; }

        public int? IdAfp { get; set; }

        public int? IdCargo { get; set; }

        public decimal Sueldo { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }
}
