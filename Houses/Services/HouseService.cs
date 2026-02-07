using Houses.Core;
using Houses.Enums;
using Houses.Houses;
using Houses.Responses;

namespace Houses.Services;

public class HouseService : IHouseService
{
    public CreateHouseResponse Create(Style style, int desiredBedrooms)
    {
        // My goal with this approach is ensure that each house style is completely decoupled from the others.
        // My take-away from reading the rules of each house style is while each house style could be derived
        // from a shared abstract base, they don't share enough interoperable properties between the styles
        // to make coupling them outweigh the benefits that separating them gains us, with the big one being
        // maintainability as bugs cannot propagate through each style while they are separate from each other.
        // It also means adding new styles doesn't require us to potentially break functionality in existing styles.

        // For example the tax-band of a style is not linked in any way between the styles,
        // same goes for whether a style has a garage or not, these properties are just arbitrary.

        // The only rules that encompass each style are the min and max number of bedrooms. But these quickly breakdown
        // as some styles override these properties.

        // Each style being responsible for defining its own rules ensures that modifications of styles or the addition
        // of new styles don't present a new vector for bugs to propagate into existing styles.

        // --

        // House style discovery could be enhanced with reflection and some attributes
        // but since we only have three using a switch statemen is simple enough.
        // Though if there was a need to enumerate all the house styles in other
        // places then this could be reconsidered.

        IHouse house = style switch
        {
            Style.Terraced => new TerracedHouse(desiredBedrooms),
            Style.SemiDetached => new SemiDetachedHouse(desiredBedrooms),
            Style.Detached => new DetachedHouse(desiredBedrooms),
            _ => throw new ArgumentOutOfRangeException(nameof(style), style, null),
        };

        // Enums value are returned as strings to make public consumption easier
        // as our internal enums won't mean much as integers to the outside world

        return new CreateHouseResponse
        {
            Bathrooms = house.GetBathrooms(),
            HasGarage = house.HasGarage(),
            Style = style.ToString(),
            Bedrooms = house.GetBedrooms(),
            TaxBand = house.GetTaxBand().ToString(),
        };
    }
}
