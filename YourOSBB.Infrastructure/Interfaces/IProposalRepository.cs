using YourOSBB.Entities;

namespace YourOSBB.Infrastructure.Interfaces;

public interface IProposalRepository : IRepository<Proposal>
{
    public Task Update(Proposal entity);
}