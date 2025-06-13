using System.ComponentModel.DataAnnotations;

namespace Zadanie_Rekrutacyjne.Entities;

public class FlightRoute
{
    private const string Africa = nameof(Africa);
    public required FlightRoutDetails RouteFrom { get; set; }
    public required FlightRoutDetails RouteTo { get; set; }

    public bool IsToAfrica()
    {
        return RouteTo.Continent.ToLower().Contains(Africa.ToLower());
    }
}
