using Microsoft.EntityFrameworkCore;
using YourOSBB.Entities.VotingEntities;
using YourOSBB.Infrastructure.Interfaces;

namespace YourOSBB.Infrastructure.Repositories;

public class PollRepository : Repository<Poll>, IPollRepository
{
    public PollRepository(DbContext dbContext) : base(dbContext)
    {
    }
}