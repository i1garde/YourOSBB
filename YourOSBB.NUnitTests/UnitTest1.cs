using YourOSBB.Entities;
using YourOSBB.Entities.VotingEntities;

namespace YourOSBB.NUnitTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
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
        
        Assert.AreEqual(announcement, cl);
    }
    [Test]
    public void TestRole()
    {
        ApplicationRole role = new ApplicationRole
        {
            Name = "a"
        };
        var cl = role;

        ApplicationRole role1 = new ApplicationRole("qq");
        var cl1 = role;
        
        Assert.AreEqual(role, cl);
        Assert.AreEqual(role1, cl1);
    }
    [Test]
    public void TestUser()
    {
        ApplicationUser test = new ApplicationUser();
        var cl = test;
        Assert.AreEqual(test, cl);
    }
    [Test]
    public void TestComplaint()
    {
        Complaint test = new Complaint();
        var cl = test;
        Assert.AreEqual(test, cl);
    }
    [Test]
    public void TestNameRecord()
    {
        NameRecord test = new NameRecord(String.Empty);
        var cl = test;
        Assert.AreEqual(test, cl);
    }
    [Test]
    public void TestOsbb()
    {
        Osbb test = new Osbb();
        var cl = test;
        Assert.AreEqual(test, cl);
    }
    [Test]
    public void TestProposal()
    {
        Proposal test = new Proposal();
        var cl = test;
        Assert.AreEqual(test, cl);
    }
    [Test]
    public void TestTariff()
    {
        Tariff test = new Tariff();
        var cl = test;
        Assert.AreEqual(test, cl);
    }
    [Test]
    public void TestPoll()
    {
        Poll test = new Poll();
        var cl = test;
        Assert.AreEqual(test, cl);
    }
    [Test]
    public void TestCompletedPoll()
    {
        CompletedPoll test = new CompletedPoll();
        var cl = test;
        Assert.AreEqual(test, cl);
    }
    [Test]
    public void TestPollCandidate()
    {
        PollCandidate test = new PollCandidate();
        var cl = test;
        Assert.AreEqual(test, cl);
    }
    [Test]
    public void TestUserVote()
    {
        UserVote test = new UserVote();
        var cl = test;
        Assert.AreEqual(test, cl);
    }
}