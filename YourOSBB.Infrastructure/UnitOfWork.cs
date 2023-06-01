using Microsoft.AspNetCore.Identity;
using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;
using YourOSBB.Infrastructure.Repositories;

namespace YourOSBB.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    public IOsbbRepository OsbbRepository { get; private set; }
    public IApplicationUserRepository ApplicationUserRepository { get; private set; }
    public IAnnouncementRepository AnnouncementRepository { get; private set; }
    public IProposalRepository ProposalRepository { get; private set; }
    public IComplaintRepository ComplaintRepository { get; private set; }
    public ITariffRepository TariffRepository { get; private set; }
    public IPollRepository PollRepository { get; private set; }
    public IPollCandidateRepository PollCandidateRepository { get; private set; }
    public IUserVoteRepository UserVoteRepository { get; private set; }
    public ICompletedPollRepository CompletedPollRepository { get; private set; }
    public UserManager<ApplicationUser> ApplicationUserManager { get; private set; }
    
    private readonly ApplicationDbContext _dbContext;
    
    public UnitOfWork(
        ApplicationDbContext dbContext,
        UserManager<ApplicationUser> userManager)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        ApplicationUserManager = userManager;
        OsbbRepository = new OsbbRepository(dbContext);
        ApplicationUserRepository = new ApplicationUserRepository(dbContext);
        AnnouncementRepository = new AnnouncementRepository(dbContext);
        ProposalRepository = new ProposalRepository(dbContext);
        ComplaintRepository = new ComplaintRepository(dbContext);
        TariffRepository = new TariffRepository(dbContext);
        PollRepository = new PollRepository(dbContext);
        PollCandidateRepository = new PollCandidateRepository(dbContext);
        UserVoteRepository = new UserVoteRepository(dbContext);
        CompletedPollRepository = new CompletedPollRepository(dbContext);
    }
    
    public async Task DoAsync() => await _dbContext.SaveChangesAsync();
    
    private bool _disposed;
    
    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)         
            {
                await _dbContext.DisposeAsync();
            }
            _disposed = true;
        }
    }
}