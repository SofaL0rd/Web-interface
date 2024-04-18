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
//    public class QuestLineController : ControllerBase
//    {
//        private readonly IQuestLineService _questLineService;

//        public QuestLineController(IQuestLineService questLineService)
//        {
//            _questLineService = questLineService;
//        }

//        [MapToApiVersion("2.0")]
//        [Authorize]
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<QuestLine>>> Get()
//        {
//            var questLines = await _questLineService.GetAllQuestLinesAsync();
//            return Ok(questLines);
//        }

//        [MapToApiVersion("2.0")]
//        [Authorize]
//        [HttpPost]
//        public async Task<ActionResult<QuestLine>> Post([FromBody] QuestLine questLine)
//        {
//            var createdQuestLine = await _questLineService.CreateQuestLineAsync(questLine);
//            return CreatedAtAction(nameof(Get), new { id = createdQuestLine.Id }, createdQuestLine);
//        }

//        [MapToApiVersion("2.0")]
//        [Authorize]
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Put(int id, [FromBody] QuestLine questLine)
//        {
//            if (id != questLine.Id)
//            {
//                return BadRequest();
//            }

//            await _questLineService.UpdateQuestLineAsync(questLine);
//            return NoContent();
//        }

//        [MapToApiVersion("2.0")]
//        [Authorize]
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await _questLineService.DeleteQuestLineAsync(id);
//            return NoContent();
//        }
//    }
//}