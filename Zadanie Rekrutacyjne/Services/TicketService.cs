using System.ComponentModel.DataAnnotations;
using Zadanie_Rekrutacyjne.Entities;
using Zadanie_Rekrutacyjne.Enum;
using Zadanie_Rekrutacyjne.Repositories;

namespace Zadanie_Rekrutacyjne.Services;

/// <summary>
/// Ticket Service
/// </summary>
public interface ITicketService
{
    /// <summary>
    /// Purchase ticket.
    /// </summary>
    /// <param name="tenantId"></param>
    /// <param name="flightId"></param>
    /// <param name="flightDate"></param>
    /// <returns></returns>
    Ticket PurchaseTicket(Guid tenantId, string flightId, DateTime flightDate);
}

/// <inheritdoc cref="ITicketService"/>
public class TicketService(IEnumerable<IDiscountCriterion> discountCriterion, IFlightRepository flightRepository, ITenantRepository tenantRepository) : ITicketService
{
    private readonly IEnumerable<IDiscountCriterion> _DiscountCriterion = discountCriterion;
    private readonly IFlightRepository _flightRepository = flightRepository;
    private readonly ITenantRepository _tenantRepository = tenantRepository;

    public Ticket PurchaseTicket(Guid tenantId, string flightId, DateTime flightDate)
    {
        var tenant = _tenantRepository.GetById(tenantId) ?? throw new ValidationException("Tenant not found.");
        var flight = _flightRepository.GetById(flightId) ?? throw new ValidationException("Flight not found.");

        var flightPricePair = flight.FlightPrices.FirstOrDefault(kvp => kvp.Key.Date == flightDate.Date);
        if (flightPricePair.Key == default)
        {
            throw new ValidationException("Flight date not found.");
        }

        var (finalPrice, appliedDiscounts) = ApplyDiscounts(tenant, flight, flightPricePair.Value, flightDate);

        var ticket = new Ticket
        {
            Id = Guid.NewGuid(),
            FlightId = flightId,
            TenantId = tenant.Id,
            FinalPrice = finalPrice,
            PurchaseDate = DateTime.Now.Date,
        };

        AdditionalTenantFilters(tenant, appliedDiscounts, ticket);

        return ticket;
    }

    /// <summary>
    /// Applies discounts
    /// </summary>
    /// <param name="basePrice"></param>
    /// <returns></returns>
    private (decimal finalPrice, IEnumerable<string> appliedDescriptions) ApplyDiscounts(Tenant tenant, Flight flight, decimal basePrice, DateTime flightDate)
    {
        decimal price = basePrice;
        var descriptions = new List<string>();

        foreach (var criterion in _DiscountCriterion)
        {
            var result = criterion.Evaluate(tenant, flight, basePrice, flightDate);

            if (price - result.Amount >= 20)
            {
                price -= result.Amount;
                descriptions.Add(result.Reason);
            }
        }

        return (price, descriptions);
    }

    /// <summary>
    /// Applies tenant filters
    /// </summary>
    /// <param name="tenant"></param>
    /// <param name="appliedDiscounts"></param>
    /// <param name="ticket"></param>
    private static void AdditionalTenantFilters(Tenant tenant, IEnumerable<string> appliedDiscounts, Ticket ticket)
    {
        switch (tenant.Group)
        {
            case TenantGroup.A:
                ticket.AppliedDiscounts = appliedDiscounts;
                break;
        }
    }
}