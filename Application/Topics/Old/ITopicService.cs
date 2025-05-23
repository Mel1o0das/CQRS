namespace Application.Topics.Old;

[Obsolete("Устарело", true)]
public interface ITopicService
{
    Task<List<TopicResponseDto>> GetTopicsAsync();
    Task<TopicResponseDto> GetTopicAsync(Guid id);
    Task<TopicResponseDto> CreateTopicAsync(CreateTopicDto dto);
    Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicDto dto);
    Task DeleteTopicAsync(Guid id);
}