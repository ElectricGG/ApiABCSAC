using ABCSAC.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABCSAC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        public readonly ICargoApplication _cargoApplication;
        public CargoController(ICargoApplication cargoApplication)
        {
            _cargoApplication = cargoApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListCargos()
        {
            var response = await _cargoApplication.ListCargos();
            return Ok(response);
        }
    }
}
