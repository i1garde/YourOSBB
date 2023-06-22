using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YourOSBB.Entities;
using YourOSBB.Entities.VotingEntities;
using YourOSBB.Infrastructure.Interfaces;

namespace YourOSBB.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Osbb> Osbb { get; set; }
    public DbSet<Announcement> Announcement { get; set; }
    public DbSet<Complaint> Complaint { get; set; }
    public DbSet<Proposal> Proposal { get; set; }
    public DbSet<Tariff> Tariff { get; set; }
    public DbSet<Poll> Poll { get; set; }
    public DbSet<PollCandidate> PollCandidate { get; set; }
    public DbSet<UserVote> UserVote { get; set; }
    public DbSet<CompletedPoll> CompletedPoll { get; set; }


    public ApplicationDbContext()
    {
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ApplicationUser>(entity => { entity.ToTable("User"); });
        
        builder.Entity<Osbb>()
            .HasMany(e => e.Residents)
            .WithOne(e => e.Osbb)
            .HasForeignKey(e => e.OsbbId)
            .IsRequired(false);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
}