using YourOSBB.Entities;

namespace YourOSBB.Services.Interfaces;

public interface IComplaintService
{
    Task<IEnumerable<Complaint>> GetAll();
    Task Add(Complaint complaint);
    Task<Complaint> GetById(int id);
    Task Update(Complaint complaint);
    Task Delete(Complaint ent);
}