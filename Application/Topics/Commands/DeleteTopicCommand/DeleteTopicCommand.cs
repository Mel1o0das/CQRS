namespace Application.Topics.Commands.DeleteTopicCommand;

public record DeleteTopicCommand(Guid id) : ICommand<DeleteTopicResult>;

public record DeleteTopicResult(bool IsSuccess);
