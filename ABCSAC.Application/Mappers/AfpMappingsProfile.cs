using ABCSAC.Application.Dtos.Afp.Response;
using ABCSAC.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCSAC.Application.Mappers
{
    public class AfpMappingsProfile : Profile
    {
        public AfpMappingsProfile()
        {
            CreateMap<Afp, AfpResponseDto>()
                .ForMember(x => x.IdAfp, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}
