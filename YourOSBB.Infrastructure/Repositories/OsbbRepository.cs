using Microsoft.EntityFrameworkCore;
using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;

namespace YourOSBB.Infrastructure.Repositories;

public class OsbbRepository : Repository<Osbb>, IOsbbRepository
{
    public OsbbRepository(DbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task Update(Osbb entity)
    {
        Osbb find = await GetByIdAsync(entity.OsbbId);
        _dbContext.Entry(find).CurrentValues.SetValues(entity);
    }
}