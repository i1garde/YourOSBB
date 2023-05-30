using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;
using YourOSBB.Services.Interfaces;

namespace YourOSBB.Services;

public class OsbbService : IOsbbService
{
    private IUnitOfWork _unitOfWork;

    public OsbbService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Osbb>> GetAll() => await _unitOfWork.OsbbRepository.GetAllAsync();
    public async Task Add(Osbb osbb)
    {
        await _unitOfWork.OsbbRepository.AddAsync(osbb);
        await _unitOfWork.DoAsync();
    }

    public async Task<Osbb> GetById(int id)
    {
        return await _unitOfWork.OsbbRepository.GetByIdAsync(id);
    }

    public async Task Update(Osbb osbb)
    {
        await _unitOfWork.OsbbRepository.Update(osbb);
        await _unitOfWork.DoAsync();
    }
}