using Zadanie_Rekrutacyjne.Entities;

namespace Zadanie_Rekrutacyjne.Services;

/// <summary>
/// Discount based on African destinaction
/// </summary>
public class AfricaDiscount : IDiscountCriterion
{
    private const decimal Discount = 5;

    public DiscountResult Evaluate(Tenant tenat, Flight flight, decimal basePrice, DateTime flightDate)
    {
        bool isAsia = flight.Route.IsToAfrica();
        bool isThursday = flightDate.DayOfWeek == DayOfWeek.Thursday;
        var result = new DiscountResult
        {
            Amount = 0,
            Reason = "Africa discount"
        };

        if (!(isAsia && isThursday))
        {
            return result;
        }

        result.Amount = Discount;

        return result;
    }
}

