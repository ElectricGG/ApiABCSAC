using ABCSAC.Application.Commons.Bases.Response;
using ABCSAC.Application.Dtos.Empleado.Request;
using ABCSAC.Application.Dtos.Empleado.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCSAC.Application.Interfaces
{
    public interface IEmpleadoApplication
    {
        Task<BaseResponse<IEnumerable<EmpleadoResponseDto>>> ListEmpleados();
        Task<BaseResponse<EmpleadoResponseDto>> EmpleadoById(int IdEmpleado);
        Task<BaseResponse<bool>> RegisterEmpleado(EmpleadoRequestDto RequestDto);
        Task<BaseResponse<bool>> EditEmpleado(int IdEmpleado, EmpleadoRequestDto RequestDto);
        Task<BaseResponse<bool>> RemoveEmpleado(int IdEmpleado);
    }
}
