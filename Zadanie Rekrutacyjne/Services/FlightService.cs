using System.ComponentModel.DataAnnotations;
using Zadanie_Rekrutacyjne.Entities;
using Zadanie_Rekrutacyjne.Repositories;

namespace Zadanie_Rekrutacyjne.Services;

/// <summary>
/// Flight Service
/// </summary>
public interface IFlightService
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

/// <inheritdoc cref="IFlightService"/>
public class FlightService(IFlightRepository flightRepository) : IFlightService
{
    private readonly IFlightRepository _flightRepository = flightRepository;

    public Flight AddFlight(Flight flight)
    {
        _ = _flightRepository.GetById(flight.Id) ?? throw new ValidationException($"Flight with id {flight.Id} already exist.");

        return _flightRepository.AddFlight(flight);
    }

    public Flight? GetById(string id) => _flightRepository.GetById(id);
}
