namespace Application.Topics.Commands.UpdateTopicCommand;

public record UpdateTopicQuery(Guid id, UpdateTopicDto dto) : IQuery<UpdateTopicResult>;

public record UpdateTopicResult(TopicResponseDto Topic);

