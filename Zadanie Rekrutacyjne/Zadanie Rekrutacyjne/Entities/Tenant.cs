using Zadanie_Rekrutacyjne.Enum;

namespace Zadanie_Rekrutacyjne.Entities;

public class Tenant
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required TenantGroup Group { get; set; }
    public required DateTime BirthDate { get; set; }
}
