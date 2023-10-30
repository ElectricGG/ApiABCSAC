using ABCSAC.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABCSAC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfpController : ControllerBase
    {
        private readonly IAfpApplication _afpApplication;

        public AfpController(IAfpApplication afpApplication)
        {
            _afpApplication = afpApplication;
        }
        [HttpGet]
        public async Task<IActionResult> ListAfp()
        {
            var response = await _afpApplication.ListAfp();
            return Ok(response);
        }
    }
}
