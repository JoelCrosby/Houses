namespace Houses.Requests;

public record CreateHouseRequest
{
    public required string Style { get; init; }

    public required int Bedrooms { get; init; }

}
