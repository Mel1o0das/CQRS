namespace Application.Topics.Commands.CreateTopicCommand;

public record CreateTopicQuery(CreateTopicDto dto) : IQuery<CreateTopicResult>;

public record CreateTopicResult(TopicResponseDto Topic);

