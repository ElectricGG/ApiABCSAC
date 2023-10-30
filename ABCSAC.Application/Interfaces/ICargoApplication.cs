using ABCSAC.Application.Commons.Bases.Response;
using ABCSAC.Application.Dtos.Cargo.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCSAC.Application.Interfaces
{
    public interface ICargoApplication
    {
        Task<BaseResponse<IEnumerable<CargoResponseDto>>> ListCargos();
    }
}
