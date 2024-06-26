using api.Models;
using api.V3.TestService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using ClosedXML.Excel;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;


namespace api.v3.Controllers
{
    [ApiVersion(3.0)]
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly TelemetryClient _telemetryClient;

        public TestController(ITestService testService, TelemetryClient telemetryClient)
        {
            _testService = testService;
            _telemetryClient = telemetryClient;
        }

        [MapToApiVersion("3.0")]
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            using (_telemetryClient.StartOperation<RequestTelemetry>("TestV3Request"))
            {
                byte[] fileContents = _testService.GetExcelFile();
                return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "example.xlsx");
            }

        }
    }
}
