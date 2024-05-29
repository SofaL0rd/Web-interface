using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;


namespace api.v3.Controllers
{
    [ApiVersion("3.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")] // Change the route to avoid conflicts
    public class QuestLineController : ControllerBase
    {
        private readonly IQuestLineService _questLineService;
        private readonly TelemetryClient _telemetryClient;


        public QuestLineController(IQuestLineService questLineService, TelemetryClient telemetryClient)
        {
            _questLineService = questLineService;
            _telemetryClient = telemetryClient;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<QuestLine>>> Get()
        {
            using (_telemetryClient.StartOperation<RequestTelemetry>("GetQuestLines"))
            {
                var questLines = await _questLineService.GetAllQuestLinesAsync();
                return Ok(questLines);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<QuestLine>> Post([FromBody] QuestLine questLine)
        {
            var createdQuestLine = await _questLineService.CreateQuestLineAsync(questLine);
            _telemetryClient.TrackEvent("QuestLineCreated", new Dictionary<string, string> { { "QuestLineId", createdQuestLine.Id.ToString() } });
            return CreatedAtAction(nameof(Get), new { id = createdQuestLine.Id }, createdQuestLine);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] QuestLine questLine)
        {
            _telemetryClient.TrackEvent("PutQuestLines");
            if (id != questLine.Id)
            {
                return BadRequest();
            }

            await _questLineService.UpdateQuestLineAsync(questLine);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            _telemetryClient.TrackEvent("DeleteQuestLines");

            await _questLineService.DeleteQuestLineAsync(id);
            return NoContent();
        }
    }
}