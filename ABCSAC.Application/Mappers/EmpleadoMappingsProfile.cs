using ABCSAC.Application.Commons.Bases.Response;
using ABCSAC.Application.Dtos.Empleado.Request;
using ABCSAC.Application.Dtos.Empleado.Response;
using ABCSAC.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCSAC.Application.Mappers
{
    public class EmpleadoMappingsProfile :Profile
    {
        public EmpleadoMappingsProfile()
        {
            CreateMap<Empleado, EmpleadoResponseDto>()
                .ForMember(x => x.IdEmpleado, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Afp, x => x.MapFrom(y => y.Afp.Nombre))
                .ForMember(x => x.Cargo, x => x.MapFrom(y => y.Cargo.Nombre))
                .ReverseMap();

            CreateMap<EmpleadoRequestDto, Empleado>().ReverseMap();
        }
        
    }
}
