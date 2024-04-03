using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestLineController : ControllerBase
    {
        private readonly IQuestLineService _questLineService;

        public QuestLineController(IQuestLineService questLineService)
        {
            _questLineService = questLineService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestLine>>> Get()
        {
            var questLines = await _questLineService.GetAllQuestLinesAsync();
            return Ok(questLines);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<QuestLine>> Post([FromBody] QuestLine questLine)
        {
            var createdQuestLine = await _questLineService.CreateQuestLineAsync(questLine);
            return CreatedAtAction(nameof(Get), new { id = createdQuestLine.Id }, createdQuestLine);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] QuestLine questLine)
        {
            if (id != questLine.Id)
            {
                return BadRequest();
            }

            await _questLineService.UpdateQuestLineAsync(questLine);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _questLineService.DeleteQuestLineAsync(id);
            return NoContent();
        }
    }
}