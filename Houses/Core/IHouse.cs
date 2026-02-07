using Houses.Enums;

namespace Houses.Core;

public interface IHouse
{
    int GetBedrooms();

    int GetBathrooms();

    bool HasGarage();

    TaxBand GetTaxBand();
}
