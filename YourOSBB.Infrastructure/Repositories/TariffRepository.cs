using Microsoft.EntityFrameworkCore;
using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;

namespace YourOSBB.Infrastructure.Repositories;

public class TariffRepository : Repository<Tariff>, ITariffRepository
{
    public TariffRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task Update(Tariff entity)
    {
        Tariff find = await GetByIdAsync(entity.TariffId);
        _dbContext.Entry(find).CurrentValues.SetValues(entity);
    }
}