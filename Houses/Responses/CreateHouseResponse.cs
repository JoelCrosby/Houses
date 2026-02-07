namespace Houses.Responses;

public record CreateHouseResponse
{
    public required string Style { get; init; }

    public required int Bedrooms { get; init; }

    public required int Bathrooms { get; init; }

    public required bool HasGarage { get; init; }

    public required string TaxBand { get; init; }
}
