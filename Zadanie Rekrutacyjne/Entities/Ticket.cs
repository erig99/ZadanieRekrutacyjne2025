namespace Zadanie_Rekrutacyjne.Entities;

public class Ticket
{
    public Guid Id { get; set; } 
    public required string FlightId { get; set; }
    public Guid TenantId { get; set; }
    public decimal FinalPrice { get; set; }
    public DateTime PurchaseDate { get; set; }
    public IEnumerable<string>? AppliedDiscounts { get; set; }
}

