using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;
using YourOSBB.Services.Interfaces;

namespace YourOSBB.Services;

public class ComplaintService : IComplaintService
{
    private IUnitOfWork _unitOfWork;

    public ComplaintService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Complaint>> GetAll()
    {
        return await _unitOfWork.ComplaintRepository.GetAllAsync();
    }

    public async Task Add(Complaint complaint)
    {
        await _unitOfWork.ComplaintRepository.AddAsync(complaint);
        await _unitOfWork.DoAsync();
    }

    public async Task<Complaint> GetById(int id)
    {
        return await _unitOfWork.ComplaintRepository.GetByIdAsync(id);
    }

    public async Task Update(Complaint complaint)
    {
        await _unitOfWork.ComplaintRepository.Update(complaint);
        await _unitOfWork.DoAsync();
    }
}