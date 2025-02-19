namespace Application.Topics.Commands.DeleteTopicCommand;

public record DeleteTopicQuery(Guid id) : IQuery<DeleteTopicResult>;

public record DeleteTopicResult(bool IsSuccess);
