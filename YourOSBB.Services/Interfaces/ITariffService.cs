using YourOSBB.Entities;

namespace YourOSBB.Services.Interfaces;

public interface ITariffService
{
    Task<IEnumerable<Tariff>> GetAll();
    Task Add(Tariff tariff);
    Task<Tariff> GetById(int id);
    Task Update(Tariff tariff);
    Task Delete(Tariff tariff);
}