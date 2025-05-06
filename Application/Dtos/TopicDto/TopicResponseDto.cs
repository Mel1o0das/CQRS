namespace Application.Dtos.TopicDto;

public record TopicResponseDto(
    Guid id,
    string Title,
    string Summary,
    string TopicType,
    LocationDto Location,
    DateTime? EventStart
);