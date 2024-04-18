using api.Models;
using api.V3.TestService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using ClosedXML.Excel;


namespace api.v3.Controllers
{
    [ApiVersion(3.0)]
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [MapToApiVersion("3.0")]
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            byte[] fileContents = _testService.GetExcelFile();
            
            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "example.xlsx");
        }
    }
}
