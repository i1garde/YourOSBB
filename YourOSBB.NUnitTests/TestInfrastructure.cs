using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using YourOSBB.Entities;
using YourOSBB.Infrastructure;
using YourOSBB.Infrastructure.Interfaces;
using YourOSBB.Infrastructure.Repositories;

namespace YourOSBB.NUnitTests;

public class TestInfrastructure
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void TestUW()
    {
        var mock = new Mock<UnitOfWork>();
        mock.Setup(repo=>repo.ApplicationUserRepository.GetAllResidentsInOsbb(1)).Returns(listAU());
        var controller = mock.Object;
        
        UnitOfWork a = new UnitOfWork();
        Assert.AreEqual(3,controller.ApplicationUserRepository.GetAllResidentsInOsbb(1).Result.Count());
    }

    private async Task<IEnumerable<ApplicationUser>> listAU()
    {
        var a =  new List<ApplicationUser>();
        var fake = new ApplicationUser
        {
            Name = "Name",
            PatronymicName = "Patr",
            Surname = "Surn"
        };
        
        a.Add(fake);
        a.Add(fake);
        a.Add(fake);

        return a;
    }
}