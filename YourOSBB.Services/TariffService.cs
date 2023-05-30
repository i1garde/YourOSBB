using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;
using YourOSBB.Services.Interfaces;

namespace YourOSBB.Services;

public class TariffService : ITariffService
{
    private IUnitOfWork _unitOfWork;

    public TariffService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Tariff>> GetAll()
    {
        return await _unitOfWork.TariffRepository.GetAllAsync();
    }

    public async Task Add(Tariff tariff)
    {
        await _unitOfWork.TariffRepository.AddAsync(tariff);
        await _unitOfWork.DoAsync();
    }

    public async Task<Tariff> GetById(int id)
    {
        return await _unitOfWork.TariffRepository.GetByIdAsync(id);
    }

    public async Task Update(Tariff tariff)
    {
        await _unitOfWork.TariffRepository.Update(tariff);
        await _unitOfWork.DoAsync();
    }
}