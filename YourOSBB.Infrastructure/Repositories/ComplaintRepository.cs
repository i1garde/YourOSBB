using Microsoft.EntityFrameworkCore;
using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;

namespace YourOSBB.Infrastructure.Repositories;

public class ComplaintRepository : Repository<Complaint>, IComplaintRepository
{
    public ComplaintRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task Update(Complaint entity)
    {
        Complaint find = await GetByIdAsync(entity.ComplaintId);
        _dbContext.Entry(find).CurrentValues.SetValues(entity);
    }
}