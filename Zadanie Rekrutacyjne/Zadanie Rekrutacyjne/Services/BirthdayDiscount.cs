using Zadanie_Rekrutacyjne.Entities;

namespace Zadanie_Rekrutacyjne.Services;

/// <summary>
/// Discount based on client birthday
/// </summary>
public class BirthdayDiscount : IDiscountCriterion
{
    private const decimal Discount = 5;

    public DiscountResult Evaluate(Tenant tenat, Flight flight, decimal basePrice, DateTime flightDate)
    {
        bool isBirthday = flightDate.Month == tenat.BirthDate.Month &&
                          flightDate.Day == tenat.BirthDate.Day;

        var result = new DiscountResult
        {
            Amount = 0,
            Reason = "Birthday discount"
        };

        if (!isBirthday)
        {
            return result;
        }

        result.Amount = Discount;

        return result;
    }
}

