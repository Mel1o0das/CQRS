using Application.Dtos;

namespace Application.Topics;

public interface ITopicService
{
    Task<List<TopicResponseDto>> GetTopicsAsync();
    Task<TopicResponseDto> GetTopicAsync(Guid id);
    Task<TopicResponseDto> CreateTopicAsync(Topic topicRequestDto);
    Task<TopicResponseDto> UpdateTopicAsync(Guid id, Topic topicRequestDto);
    Task DeleteTopicAsync(Guid id);
}