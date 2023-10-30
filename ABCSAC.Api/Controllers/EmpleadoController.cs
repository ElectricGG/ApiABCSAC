using ABCSAC.Application.Dtos.Empleado.Request;
using ABCSAC.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABCSAC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoApplication _empleadoApplication;

        public EmpleadoController(IEmpleadoApplication empleadoApplication)
        {
            _empleadoApplication = empleadoApplication;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> ListEmpleados()
        {
            var response = await _empleadoApplication.ListEmpleados();
            return Ok(response);
        }

        [HttpGet("{empleadoId:int}")]
        public async Task<IActionResult> EmpleadoById(int empleadoId)
        {
            var response = await _empleadoApplication.EmpleadoById(empleadoId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterEmpleado([FromBody] EmpleadoRequestDto requestDto)
        {
            var response = await _empleadoApplication.RegisterEmpleado(requestDto);
            return Ok(response);
        }

        [HttpPut("Edit/{empleadoId:int}")]
        public async Task<IActionResult> EditEmpleado(int empleadoId, [FromBody] EmpleadoRequestDto requestDto)
        {
            var response = await _empleadoApplication.EditEmpleado(empleadoId, requestDto);
            return Ok(response);
        }

        [HttpPut("Remove/{empleadoId:int}")]
        public async Task<IActionResult> RemoveEmpleado(int empleadoId)
        {
            var response = await _empleadoApplication.RemoveEmpleado(empleadoId);
            return Ok(response);
        }
    }
}
