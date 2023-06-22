using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;
using YourOSBB.Services.Interfaces;
using System.ComponentModel;

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

    public async Task<ApplicationUser> ReturnOsbbHead(int osbbId) {
        var allUsers = await _unitOfWork.ApplicationUserRepository.GetAllAsync();
        foreach (var v in allUsers)
        {
            Console.WriteLine($"DEBUG: {v.Role}");
        }
        
        return allUsers
            .Where(x => x.OsbbId == osbbId)
            .Where(x => x.Role == Roles.OsbbHead())
            .First();
    }
}