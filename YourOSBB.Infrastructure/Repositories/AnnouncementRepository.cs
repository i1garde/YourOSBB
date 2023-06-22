using Microsoft.EntityFrameworkCore;
using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;

namespace YourOSBB.Infrastructure.Repositories;

public class AnnouncementRepository : Repository<Announcement>, IAnnouncementRepository
{
    public AnnouncementRepository(DbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task Update(Announcement entity)
    {
        Announcement find = await GetByIdAsync(entity.AnnouncementId);
        _dbContext.Entry(find).CurrentValues.SetValues(entity);
    }
}