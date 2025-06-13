using Zadanie_Rekrutacyjne.Entities;

namespace Zadanie_Rekrutacyjne.Repositories;

/// <summary>
/// Flight repository
/// </summary>
public interface IFlightRepository
{
    /// <summary>
    /// Add flight
    /// </summary>
    /// <param name="flight"></param>
    /// <returns></returns>
    Flight AddFlight(Flight flight);

    /// <summary>
    /// Get flight by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Flight? GetById(string id);
}

/// <inheritdoc cref="IFlightRepository"/>
public class FlightRepository : IFlightRepository
{
    public Flight AddFlight(Flight flight)
    {
        throw new NotImplementedException(); //returns added flight
    }

    public Flight? GetById(string id)
    {
        throw new NotImplementedException(); //returns requested flight by id
    }
}
