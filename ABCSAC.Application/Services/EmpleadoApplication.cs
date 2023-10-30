using ABCSAC.Application.Commons.Bases.Response;
using ABCSAC.Application.Dtos.Empleado.Request;
using ABCSAC.Application.Dtos.Empleado.Response;
using ABCSAC.Application.Interfaces;
using ABCSAC.Domain.Entities;
using ABCSAC.Infrastructure.Persistences.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCSAC.Application.Services
{
    public class EmpleadoApplication : IEmpleadoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmpleadoApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<IEnumerable<EmpleadoResponseDto>>> ListEmpleados()
        {
            var response = new BaseResponse<IEnumerable<EmpleadoResponseDto>>();

            try
            {
                var empleados = _unitOfWork.Empleado.
                    GetAllQueryable().
                    Include(x => x.Afp).
                    Include(x => x.Cargo).
                    AsQueryable();

                if(empleados is not null)
                {
                    response.IsSuccess = true;
                    response.TotalRecords = await empleados.CountAsync();
                    response.Data = _mapper.Map<IEnumerable<EmpleadoResponseDto>>(empleados);
                    response.Message = "Consulta exitosa.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Ocurrio una excepcion.";
                WatchDog.WatchLogger.Log(ex.Message);
            }

            return response;
        }
        public async Task<BaseResponse<bool>> RegisterEmpleado(EmpleadoRequestDto RequestDto)
        {
            var response = new BaseResponse<bool>();
            var empleado = _mapper.Map<Empleado>(RequestDto);
            try
            {
                response.Data = await _unitOfWork.Empleado.RegisterAsync(empleado);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se registro correctamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Operacion fallida.";
                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Ocurrio una excepcion.";
                WatchDog.WatchLogger.Log(ex.Message);
            }
            

            return response;
        }
        public async Task<BaseResponse<bool>> EditEmpleado(int IdEmpleado, EmpleadoRequestDto RequestDto)
        {
            var response = new BaseResponse<bool>();

            var empleadoById = await EmpleadoById(IdEmpleado);

            if (empleadoById.Data is null)
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros.";

                return response;
            }

            var empleado = _mapper.Map<Empleado>(RequestDto);

            empleado.Id = IdEmpleado;
            response.Data = await _unitOfWork.Empleado.EditAsync(empleado);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Se acutalizó correctamente.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Operacion faillda.";
            }

            return response;
        }

        public async Task<BaseResponse<EmpleadoResponseDto>> EmpleadoById(int IdEmpleado)
        {
            var response = new BaseResponse<EmpleadoResponseDto>();
            var empelado = await _unitOfWork.Empleado.GetByIdAsync(IdEmpleado);

            if (empelado is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<EmpleadoResponseDto>(empelado);
                response.Message = "Consulta exitosa.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros.";
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RemoveEmpleado(int IdEmpleado)
        {
            var response = new BaseResponse<bool>();

            var empleadoById = await EmpleadoById(IdEmpleado);

            if (empleadoById.Data is null)
            {
                response.IsSuccess = false;
                response.Message = "No se encontraron registros.";

                return response;
            }

            response.Data = await _unitOfWork.Empleado.RemoveAsync(IdEmpleado);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Se elimino correctamente.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Operacion faillda.";
            }

            return response;
        }
    }
}
