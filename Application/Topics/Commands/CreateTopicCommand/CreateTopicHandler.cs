namespace Application.Topics.Commands.CreateTopicCommand
{
    public class CreateTopicHandler(IApplicationDbContext dbContext)
        : IQueryHandler<CreateTopicQuery, CreateTopicResult>
    {
        public async Task<CreateTopicResult> Handle(CreateTopicQuery request,
            CancellationToken cancellationToken)
        {
            Topic newTopic = Topic.Create(
            TopicId.Of(Guid.NewGuid()),
            request.dto.Title,
            request.dto.EventStart,
            request.dto.Summary,
            request.dto.TopicType,
            Location.Of(request.dto.Location.City, request.dto.Location.Street)
            );

            dbContext.Topics.Add(newTopic);

            await dbContext.SaveChangesAsync(CancellationToken.None);

            return new CreateTopicResult(newTopic.ToTopicResponseDto());
        }
    }
}