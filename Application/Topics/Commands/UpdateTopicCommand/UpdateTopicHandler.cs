
using AutoMapper;

namespace Application.Topics.Commands.UpdateTopicCommand;

public class UpdateTopicHandler(IApplicationDbContext dbContext, IMapper mapper)
    : ICommandHandler<UpdateTopicCommand, UpdateTopicResult>
{
    public async Task<UpdateTopicResult> Handle(UpdateTopicCommand request,
        CancellationToken cancellationToken)
    {
        TopicId topicId = TopicId.Of(request.id);

        var topic = await dbContext.Topics.FindAsync([topicId], cancellationToken);

        if (topic is null || topic.IsDeleted)
        {
            throw new TopicNotFoundException(request.id);
        }

        mapper.Map(request.dto, topic);

        await dbContext.SaveChangesAsync(CancellationToken.None);

        return new UpdateTopicResult(topic.ToTopicResponseDto());
    }

}
