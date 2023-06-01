using Microsoft.EntityFrameworkCore;
using YourOSBB.Entities.VotingEntities;
using YourOSBB.Infrastructure.Interfaces;

namespace YourOSBB.Infrastructure.Repositories;

public class CompletedPollRepository : Repository<CompletedPoll>, ICompletedPollRepository
{
    public CompletedPollRepository(DbContext dbContext) : base(dbContext)
    {
    }
}