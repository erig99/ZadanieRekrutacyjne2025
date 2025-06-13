using Zadanie_Rekrutacyjne.Entities;

namespace Zadanie_Rekrutacyjne.Repositories;

/// <summary>
/// Tenant repository.
/// </summary>
public interface ITenantRepository
{
    /// <summary>
    /// Gets tenant by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Tenant? GetById(Guid id);
}

public class TenantRepository : ITenantRepository
{
    public Tenant? GetById(Guid id)
    {
        throw new NotImplementedException(); //returns tenant by id
    }
}
