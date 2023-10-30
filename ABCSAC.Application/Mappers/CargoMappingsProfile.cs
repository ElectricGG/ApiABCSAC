using ABCSAC.Application.Dtos.Cargo.Response;
using ABCSAC.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCSAC.Application.Mappers
{
    public class CargoMappingsProfile : Profile
    {
        public CargoMappingsProfile()
        {
            CreateMap<Cargo, CargoResponseDto>()
                .ForMember(x => x.IdCargo, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}
