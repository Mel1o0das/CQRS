using Application.Dtos;
using Application.Topics;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController(ITopicService topicService)
        : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TopicResponseDto>>> GetTopics()
        {
            return Ok(await topicService.GetTopicsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TopicResponseDto>> GetTopic(Guid id)
        {
            return Ok(await topicService.GetTopicAsync(id));
        }
    }
}
