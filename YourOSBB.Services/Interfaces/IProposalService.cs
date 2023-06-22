using YourOSBB.Entities;

namespace YourOSBB.Services.Interfaces;

public interface IProposalService
{
    Task<IEnumerable<Proposal>> GetAll();
    Task Add(Proposal proposal);
    Task<Proposal> GetById(int id);
    Task Update(Proposal proposal);
    Task Delete(Proposal ent);
}