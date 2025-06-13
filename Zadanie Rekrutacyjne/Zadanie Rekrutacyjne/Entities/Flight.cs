using System.ComponentModel.DataAnnotations;

namespace Zadanie_Rekrutacyjne.Entities;

public class Flight
{
    [Key]
    [Required]
    [MaxLength(11)]
    [RegularExpression(@"^[A-Z]{3}\d{5}[A-Z]{3}$", ErrorMessage = "Flight ID must be in format: 3 letters + 5 digits + 3 letters, e.g. KLM12345ABC.")]
    public required string Id { get; set; }
    public required FlightRoute Route { get; set; }
    public TimeOnly DepartureTime { get; set; }
    public required IDictionary<DateTime, decimal> FlightPrices { get; set; }
}