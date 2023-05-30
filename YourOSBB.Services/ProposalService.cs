using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;
using YourOSBB.Services.Interfaces;

namespace YourOSBB.Services;

public class ProposalService : IProposalService
{
    private IUnitOfWork _unitOfWork;

    public ProposalService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Proposal>> GetAll()
    {
        return await _unitOfWork.ProposalRepository.GetAllAsync();
    }

    public async Task Add(Proposal proposal)
    {
        await _unitOfWork.ProposalRepository.AddAsync(proposal);
        await _unitOfWork.DoAsync();
    }

    public async Task<Proposal> GetById(int id)
    {
        return await _unitOfWork.ProposalRepository.GetByIdAsync(id);
    }

    public async Task Update(Proposal proposal)
    {
        await _unitOfWork.ProposalRepository.Update(proposal);
        await _unitOfWork.DoAsync();
    }
}