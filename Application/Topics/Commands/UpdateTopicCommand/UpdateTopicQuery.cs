namespace Application.Topics.Commands.UpdateTopicCommand;

public record UpdateTopicCommand(Guid id, UpdateTopicDto dto) : ICommand<UpdateTopicResult>;

public record UpdateTopicResult(TopicResponseDto Topic);

