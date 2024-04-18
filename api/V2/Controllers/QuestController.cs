//using api.Models;
//using api.Services;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Asp.Versioning;


//namespace api.v2.Controllers
//{
//    [ApiVersion(2.0)]
//    [ApiController]
//    [Route("api/[controller]")] // Change the route to avoid conflicts
//    public class QuestController : ControllerBase
//    {
//        private readonly IQuestService _questService;

//        public QuestController(IQuestService questService)
//        {
//            _questService = questService;
//        }

//        [MapToApiVersion("2.0")]
//        [Authorize]
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Quest>>> Get()
//        {
//            var quests = await _questService.GetAllQuestsAsync();
//            return Ok(quests);
//        }

//        [MapToApiVersion("2.0")]
//        [Authorize]
//        [HttpPost]
//        public async Task<ActionResult<Quest>> Post([FromBody] Quest quest)
//        {
//            var createdQuest = await _questService.CreateQuestAsync(quest);
//            return CreatedAtAction(nameof(Get), new { id = createdQuest.Id }, createdQuest);
//        }

//        [MapToApiVersion("2.0")]
//        [Authorize]
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Put(int id, [FromBody] Quest quest)
//        {
//            if (id != quest.Id)
//            {
//                return BadRequest();
//            }

//            await _questService.UpdateQuestAsync(quest);
//            return NoContent();
//        }

//        [Authorize]
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await _questService.DeleteQuestAsync(id);
//            return NoContent();
//        }
//    }
//}
