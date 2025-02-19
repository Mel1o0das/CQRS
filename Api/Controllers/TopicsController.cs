using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController
        : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TopicResponseDto>>> GetTopics()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TopicResponseDto>> GetTopic(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<TopicResponseDto>> CreateTopic(CreateTopicDto dto)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TopicResponseDto>> UpdateTopic(Guid id,
            [FromBody] UpdateTopicDto dto)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TopicResponseDto>> DeleteTopic(Guid id)
        {
            return NoContent();
        }
    }
}
