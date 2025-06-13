using System.ComponentModel.DataAnnotations;

namespace Zadanie_Rekrutacyjne.Entities;

public class FlightPrice
{
    public Guid FlightId { get; }
    public DateTime Date { get; }
    public decimal Price { get; }

    public FlightPrice(Guid flightId, DateTime date, decimal price)
    {
        if (price < 0)
        {
            throw new ValidationException("Price cannot be negative.");
        }

        FlightId = flightId;
        Date = date;
        Price = price;
    }
}
