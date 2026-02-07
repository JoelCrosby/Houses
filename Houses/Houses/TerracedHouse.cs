using Houses.Core;
using Houses.Enums;

namespace Houses.Houses;

public class TerracedHouse(int desiredBedrooms) : IHouse
{
    private const int MinBedrooms = 2;
    private const int MaxBedrooms = 3;

    public int GetBedrooms()
    {
        return desiredBedrooms switch
        {
            < MinBedrooms => MinBedrooms,
            > MaxBedrooms => MaxBedrooms,
            _ => desiredBedrooms,
        };
    }

    // Family bathroom
    public int GetBathrooms() => 1;

    public bool HasGarage() => false;

    public TaxBand GetTaxBand() => TaxBand.A;
}
