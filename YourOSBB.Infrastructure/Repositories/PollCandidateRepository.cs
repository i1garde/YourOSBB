using Microsoft.EntityFrameworkCore;
using YourOSBB.Entities.VotingEntities;
using YourOSBB.Infrastructure.Interfaces;

namespace YourOSBB.Infrastructure.Repositories;

public class PollCandidateRepository : Repository<PollCandidate>, IPollCandidateRepository
{
    public PollCandidateRepository(DbContext dbContext) : base(dbContext)
    {
    }
}