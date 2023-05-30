using YourOSBB.Entities;

namespace YourOSBB.Infrastructure.Interfaces;

public interface IComplaintRepository : IRepository<Complaint>
{
    public Task Update(Complaint entity);
}