namespace Application.Topics.Commands.CreateTopicCommand;

public record CreateTopicCommand(CreateTopicDto dto) : ICommand<CreateTopicResult>;

public record CreateTopicResult(TopicResponseDto Topic);

