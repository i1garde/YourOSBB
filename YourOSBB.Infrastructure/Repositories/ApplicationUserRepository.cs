using Microsoft.EntityFrameworkCore;
using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;

namespace YourOSBB.Infrastructure.Repositories;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    public ApplicationUserRepository(DbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task Update(ApplicationUser entity)
    {
        ApplicationUser find = await GetByIdAsync(entity.Id);
        _dbContext.Entry(find).CurrentValues.SetValues(entity);
    }
    
    public async Task<IEnumerable<ApplicationUser>> GetAllResidentsInOsbb(int osbbId)
    {
        IEnumerable<ApplicationUser> find = await _dbSet.ToListAsync();
        return find.Where(x => x.OsbbId == osbbId);
    }
}
