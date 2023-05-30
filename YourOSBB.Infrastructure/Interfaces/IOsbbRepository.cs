using YourOSBB.Entities;

namespace YourOSBB.Infrastructure.Interfaces;

public interface IOsbbRepository : IRepository<Osbb>
{
    public Task Update(Osbb entity);
}