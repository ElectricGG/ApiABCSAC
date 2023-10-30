using ABCSAC.Application.Commons.Bases.Response;
using ABCSAC.Application.Dtos.Cargo.Response;
using ABCSAC.Application.Interfaces;
using ABCSAC.Infrastructure.Persistences.Interfaces;
using AutoMapper;
using WatchDog;

namespace ABCSAC.Application.Services
{
    public class CargoApplication : ICargoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CargoApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<CargoResponseDto>>> ListCargos()
        {
            var response = new BaseResponse<IEnumerable<CargoResponseDto>>();

            try
            {
                var cargos = await _unitOfWork.Cargo.GetSelectAsync();
                if (cargos is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<CargoResponseDto>>(cargos);
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Occurrio una excepcion.";
                WatchLogger.Log(ex.Message);
            }

            return response;
        }
    }
}
