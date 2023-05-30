using Microsoft.EntityFrameworkCore;
using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;

namespace YourOSBB.Infrastructure.Repositories;

public class ProposalRepository : Repository<Proposal>, IProposalRepository
{
    public ProposalRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task Update(Proposal entity)
    {
        Proposal find = await GetByIdAsync(entity.ProposalId);
        _dbContext.Entry(find).CurrentValues.SetValues(entity);
    }
}