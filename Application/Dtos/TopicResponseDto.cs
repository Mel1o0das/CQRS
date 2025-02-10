namespace Application.Dtos;

public record TopicResponseDto(
    Guid id,
    string Title,
    string Summary,
    string TopicType,
    LocationDto Location,
    DateTime? EventStart
);