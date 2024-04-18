using api.Models;
using api.V1.TestService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;



namespace api.v1.Controllers
{

    [ApiVersion(1.0, Deprecated = true)]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService) {
        
            _testService = testService;
        }

        [MapToApiVersion(1.0)]
        [HttpGet]
        [Authorize]
        public IActionResult GetV1()
        {
            int value = _testService.GetValue() ;
           
            return Ok(value);
        }

       

    }
}
