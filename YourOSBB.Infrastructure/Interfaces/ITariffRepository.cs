using YourOSBB.Entities;

namespace YourOSBB.Infrastructure.Interfaces;

public interface ITariffRepository : IRepository<Tariff>
{
    public Task Update(Tariff entity);
}