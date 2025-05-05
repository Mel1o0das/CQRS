namespace Application.Topics.Commands.DeleteTopicCommand;

public class DeleteCommandHandler(IApplicationDbContext dbContext) :
    IQueryHandler<DeleteTopicQuery, DeleteTopicResult>
{
    public async Task<DeleteTopicResult> Handle(DeleteTopicQuery request,
        CancellationToken cancellationToken)
    {
        TopicId topicId = TopicId.Of(request.id);
        var topic = await dbContext.Topics.FindAsync([topicId], cancellationToken);

        if (topic is null || topic.IsDeleted)
        {
            throw new TopicNotFoundException(request.id);
        }

        topic.IsDeleted = true;
        topic.DeletedAt = DateTimeOffset.UtcNow;

        await dbContext.SaveChangesAsync(CancellationToken.None);
        return new DeleteTopicResult(true);
    }
}
