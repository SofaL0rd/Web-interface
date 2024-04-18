using api.Models;
using api.v2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;


namespace api.v2.Controllers
{
    [ApiVersion(2.0)]
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            string value = _testService.GetValue();
            return Ok(value);
        }
    }
}
