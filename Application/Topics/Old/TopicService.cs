using Microsoft.Extensions.Logging;

namespace Application.Topics.Old;

[Obsolete("Устарело", true)]
public class TopicService
    (IApplicationDbContext dbContext) : ITopicService
{
    public async Task<TopicResponseDto> CreateTopicAsync(CreateTopicDto dto)
    {
        Topic newTopic = Topic.Create(
            TopicId.Of(Guid.NewGuid()),
            dto.Title,
            dto.EventStart,
            dto.Summary,
            dto.TopicType,
            Location.Of(dto.Location.City, dto.Location.Street)
        );

        dbContext.Topics.Add(newTopic);

        await dbContext.SaveChangesAsync(CancellationToken.None);

        return newTopic.ToTopicResponseDto();
    }

    public async Task DeleteTopicAsync(Guid id)
    {
        TopicId topicId = TopicId.Of(id);
        var topic = await dbContext.Topics.FindAsync([topicId]);

        if (topic is null || topic.IsDeleted)
        {
            throw new TopicNotFoundException(id);
        }

        topic.IsDeleted = true;
        topic.DeletedAt = DateTimeOffset.UtcNow;

        //dbContext.Topics.Remove(topic);
        await dbContext.SaveChangesAsync(CancellationToken.None);
    }

    public async Task<TopicResponseDto> GetTopicAsync(Guid id)
    {
        TopicId topicId = TopicId.Of(id);
        var topic = await dbContext.Topics.FindAsync([topicId]);

        if (topic is null || topic.IsDeleted)
        {
            throw new TopicNotFoundException(id);
        }

        return topic.ToTopicResponseDto();
    }

    public async Task<List<TopicResponseDto>> GetTopicsAsync()
    {
        var topics = await dbContext.Topics
            .AsNoTracking()
            .Where(t => !t.IsDeleted)
            .ToListAsync();

        return topics.ToTopicResponseDtoList();
    }

    public async Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicDto dto)
    {
        TopicId topicId = TopicId.Of(id);

        var topic = await dbContext.Topics.FindAsync([topicId]);

        if (topic is null || topic.IsDeleted)
        {
            throw new TopicNotFoundException(id);
        }

        topic.Title = dto.Title ?? topic.Title;
        topic.Summary = dto.Summary ?? topic.Summary;
        topic.TopicType = dto.TopicType ?? topic.TopicType;
        topic.EventStart = dto.EventStart;
        topic.Location = Location.Of(
            dto.Location.City,
            dto.Location.Street
        );

        await dbContext.SaveChangesAsync(CancellationToken.None);

        return topic.ToTopicResponseDto();
    }
}