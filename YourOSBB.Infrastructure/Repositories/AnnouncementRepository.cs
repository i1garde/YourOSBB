using Microsoft.EntityFrameworkCore;
using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;

namespace YourOSBB.Infrastructure.Repositories;

public class AnnouncementRepository : Repository<Announcement>, IAnnouncementRepository
{
    public AnnouncementRepository(DbContext dbContext) : base(dbContext)
    {
    }
}