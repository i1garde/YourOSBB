using Microsoft.EntityFrameworkCore;
using YourOSBB.Entities.VotingEntities;
using YourOSBB.Infrastructure.Interfaces;

namespace YourOSBB.Infrastructure.Repositories;

public class UserVoteRepository : Repository<UserVote>, IUserVoteRepository
{
    public UserVoteRepository(DbContext dbContext) : base(dbContext)
    {
    }
}