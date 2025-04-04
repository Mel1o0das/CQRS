namespace Application.Topics.Commands.CreateTopicCommand
{
    public class CreateTopicHandler(IApplicationDbContext dbContext, IMapper mapper)
        : IQueryHandler<CreateTopicQuery, CreateTopicResult>
    {
        public async Task<CreateTopicResult> Handle(CreateTopicQuery request,
            CancellationToken cancellationToken)
        {
            // Topic newTopic = Topic.Create(
            // TopicId.Of(Guid.NewGuid()),
            // request.dto.Title,
            // request.dto.EventStart,
            // request.dto.Summary,
            // request.dto.TopicType,
            // Location.Of(request.dto.Location.City, request.dto.Location.Street)
            // );

            var newTopic = mapper.Map<Topic>(request.dto);

            dbContext.Topics.Add(newTopic);

            await dbContext.SaveChangesAsync(CancellationToken.None);

            return new CreateTopicResult(newTopic.ToTopicResponseDto());
        }
    }
}