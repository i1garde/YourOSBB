using YourOSBB.Entities;

namespace YourOSBB.Services.Interfaces;

public interface IOsbbService
{
    Task<IEnumerable<Osbb>> GetAll();
    Task Add(Osbb osbb);
    Task<Osbb> GetById(int id);
    Task Update(Osbb osbb);
}