using Zadanie_Rekrutacyjne.Entities;

namespace Zadanie_Rekrutacyjne.Services;

/// <summary>
/// Discount criterion
/// </summary>
public interface IDiscountCriterion
{
    /// <summary>
    /// Evaluate applied discounts
    /// </summary>
    /// <param name="basePrice"></param>
    /// <param name="flight"></param>
    /// <param name="flightDate"></param>
    /// <param name="tenat"></param>
    /// <returns></returns>
    DiscountResult Evaluate(Tenant tenat, Flight flight, decimal basePrice, DateTime flightDate);
}
