
using Application.Data.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Topics;

public class TopicService
    (IApplicationDbContext dbContext,
     ILogger<TopicService> logger) : ITopicService
{
    public Task<Topic> CreateTopicAsync(Topic topicRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTopicAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Topic> GetTopicAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Topic>> GetTopicsAsync()
    {
        var topics = await dbContext.Topics
            .AsNoTracking()
            .ToListAsync();

        return topics;
    }

    public Task<Topic> UpdateTopicAsync(Guid id, Topic topicRequestDto)
    {
        throw new NotImplementedException();
    }
}