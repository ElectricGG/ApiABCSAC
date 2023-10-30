using ABCSAC.Application.Commons.Bases.Response;
using ABCSAC.Application.Dtos.Afp.Response;
using ABCSAC.Application.Interfaces;
using ABCSAC.Infrastructure.Persistences.Interfaces;
using AutoMapper;
using WatchDog;

namespace ABCSAC.Application.Services
{
    public class AfpApplication : IAfpApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AfpApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<IEnumerable<AfpResponseDto>>> ListAfp()
        {
            var response = new BaseResponse<IEnumerable<AfpResponseDto>>();

            try
            {
                var afps = await _unitOfWork.Afp.GetSelectAsync();
                if (afps is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<AfpResponseDto>>(afps);
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
