using YourOSBB.Entities;
using YourOSBB.Entities.VotingEntities;

namespace YourOSBB.Tests;

public class UnitTestEntities
{
    [Fact]
    public void TestAnnouncement()
    {
        Announcement announcement = new Announcement
        {
            AnnouncementId = 1,
            Date = DateTime.MaxValue,
            Name = "Ivan",
            OsbbId = 1,
            Text = "SomeText",
            UserId = 1
        };
        var cl = announcement;
        
        Assert.Equal(announcement, cl);
    }
    [Fact]
    public void TestRole()
    {
        ApplicationRole role = new ApplicationRole
        {
            Name = "a"
        };
        var cl = role;
        
        Assert.Equal(role, cl);
    }
    [Fact]
    public void TestUser()
    {
        ApplicationUser test = new ApplicationUser();
        var cl = test;
        Assert.Equal(test, cl);
    }
    [Fact]
    public void TestComplaint()
    {
        Complaint test = new Complaint();
        var cl = test;
        Assert.Equal(test, cl);
    }
    [Fact]
    public void TestNameRecord()
    {
        NameRecord test = new NameRecord(String.Empty);
        var cl = test;
        Assert.Equal(test, cl);
    }
    [Fact]
    public void TestOsbb()
    {
        Osbb test = new Osbb();
        var cl = test;
        Assert.Equal(test, cl);
    }
    [Fact]
    public void TestProposal()
    {
        Proposal test = new Proposal();
        var cl = test;
        Assert.Equal(test, cl);
    }
    [Fact]
    public void TestTariff()
    {
        Tariff test = new Tariff();
        var cl = test;
        Assert.Equal(test, cl);
    }
    [Fact]
    public void TestPoll()
    {
        Poll test = new Poll();
        var cl = test;
        Assert.Equal(test, cl);
    }
    [Fact]
    public void TestCompletedPoll()
    {
        CompletedPoll test = new CompletedPoll();
        var cl = test;
        Assert.Equal(test, cl);
    }
    [Fact]
    public void TestPollCandidate()
    {
        PollCandidate test = new PollCandidate();
        var cl = test;
        Assert.Equal(test, cl);
    }
    [Fact]
    public void TestUserVote()
    {
        UserVote test = new UserVote();
        var cl = test;
        Assert.Equal(test, cl);
    }
}