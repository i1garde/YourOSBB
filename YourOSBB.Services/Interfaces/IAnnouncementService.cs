using YourOSBB.Entities;

namespace YourOSBB.Services.Interfaces;

public interface IAnnouncementService
{
    Task Add(Announcement ent);
    Task Delete(Announcement ent);
    Task<Announcement> GetById(int id);
    Task<IEnumerable<Announcement>> GetAll();
    Task Update(Announcement announcement);
}