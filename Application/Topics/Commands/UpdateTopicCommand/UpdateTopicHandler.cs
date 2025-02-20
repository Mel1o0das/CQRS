
namespace Application.Topics.Commands.UpdateTopicCommand;

public class UpdateTopicHandler(IApplicationDbContext dbContext)
    : IQueryHandler<UpdateTopicQuery, UpdateTopicResult>
{
    public async Task<UpdateTopicResult> Handle(UpdateTopicQuery request,
        CancellationToken cancellationToken)
    {
        TopicId topicId = TopicId.Of(request.id);

        var topic = await dbContext.Topics.FindAsync([topicId], cancellationToken);

        if (topic is null || topic.IsDeleted)
        {
            throw new TopicNotFoundException(request.id);
        }

        topic.Title = request.dto.Title ?? topic.Title;
        topic.Summary = request.dto.Summary ?? topic.Summary;
        topic.TopicType = request.dto.TopicType ?? topic.TopicType;
        topic.EventStart = request.dto.EventStart;
        topic.Location = Location.Of(
            request.dto.Location.City,
            request.dto.Location.Street
        );

        await dbContext.SaveChangesAsync(CancellationToken.None);

        return new UpdateTopicResult(topic.ToTopicResponseDto());
    }

}
