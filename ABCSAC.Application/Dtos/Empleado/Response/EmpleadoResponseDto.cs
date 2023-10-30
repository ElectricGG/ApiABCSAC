using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCSAC.Application.Dtos.Empleado.Response
{
    public class EmpleadoResponseDto
    {
        public int IdEmpleado { get; set; }
        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaIngreso { get; set; }

        public string? Afp { get; set; }

        public string? Cargo { get; set; }

        public decimal Sueldo { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }
}
