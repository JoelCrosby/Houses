using Houses.Enums;
using Houses.Responses;

namespace Houses.Core;

public interface IHouseService
{
    CreateHouseResponse Create(Style style, int desiredBedrooms);
}
