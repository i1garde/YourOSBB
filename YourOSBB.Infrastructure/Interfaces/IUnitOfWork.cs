using Microsoft.AspNetCore.Identity;
using YourOSBB.Entities;

namespace YourOSBB.Infrastructure.Interfaces;

public interface IUnitOfWork : IAsyncDisposable
{
    IOsbbRepository OsbbRepository { get; }
    IApplicationUserRepository ApplicationUserRepository { get; }
    IAnnouncementRepository AnnouncementRepository { get; }
    IProposalRepository ProposalRepository { get; }
    IComplaintRepository ComplaintRepository { get; }
    ITariffRepository TariffRepository { get; }
    UserManager<ApplicationUser> ApplicationUserManager { get; }
 
    Task DoAsync();
}