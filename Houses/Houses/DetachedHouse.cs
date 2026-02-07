using Houses.Core;
using Houses.Enums;

namespace Houses.Houses;

public class DetachedHouse(int desiredBedrooms) : IHouse
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

    // Family bathroom + 3 en-suits
    public int GetBathrooms() => 4;

    public bool HasGarage() => true;

    public TaxBand GetTaxBand() => TaxBand.C;
}
