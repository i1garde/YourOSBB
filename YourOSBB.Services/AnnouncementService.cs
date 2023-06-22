using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;
using YourOSBB.Services.Interfaces;

namespace YourOSBB.Services;

public class AnnouncementService : IAnnouncementService
{
    private IUnitOfWork _unitOfWork;
    
    public AnnouncementService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Add(Announcement ent)
    {
        await _unitOfWork.AnnouncementRepository.AddAsync(ent);
        await _unitOfWork.DoAsync();
    }

    public async Task Delete(Announcement ent)
    {
        await _unitOfWork.AnnouncementRepository.DeleteAsync(ent);
        await _unitOfWork.DoAsync();
    }

    public async Task<Announcement> GetById(int id)
    {
        return await _unitOfWork.AnnouncementRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Announcement>> GetAll()
    {
        return await _unitOfWork.AnnouncementRepository.GetAllAsync();
    }
    
    public async Task Update(Announcement announcement)
    {
        await _unitOfWork.AnnouncementRepository.Update(announcement);
        await _unitOfWork.DoAsync();
    }
}