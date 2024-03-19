using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly IQuestService _questService;

        public QuestController(IQuestService questService)
        {
            _questService = questService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quest>>> Get()
        {
            var quests = await _questService.GetAllQuestsAsync();
            return Ok(quests);
        }

        [HttpPost]
        public async Task<ActionResult<Quest>> Post([FromBody] Quest quest)
        {
            var createdQuest = await _questService.CreateQuestAsync(quest);
            return CreatedAtAction(nameof(Get), new { id = createdQuest.Id }, createdQuest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Quest quest)
        {
            if (id != quest.Id)
            {
                return BadRequest();
            }

            await _questService.UpdateQuestAsync(quest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _questService.DeleteQuestAsync(id);
            return NoContent();
        }
    }
}
