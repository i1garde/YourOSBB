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
}
