using YourOSBB.Entities;

namespace YourOSBB.Infrastructure.Interfaces;

public interface IAnnouncementRepository : IRepository<Announcement>
{
    Task Update(Announcement entity);
}