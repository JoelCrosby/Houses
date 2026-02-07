using Houses.Core;
using Houses.Enums;

namespace Houses.Houses;

public class SemiDetachedHouse(int desiredBedrooms) : IHouse
{
    private const int MinBedrooms = 3;
    private const int MaxBedrooms = 5;

    public int GetBedrooms()
    {
        return desiredBedrooms switch
        {
            < MinBedrooms => MinBedrooms,
            > MaxBedrooms => MaxBedrooms,
            _ => desiredBedrooms,
        };
    }

    // Family bathroom + 1 master bedroom en-suit
    public int GetBathrooms() => 2;

    public bool HasGarage() => true;

    public TaxBand GetTaxBand() => TaxBand.B;
}
