using Microsoft.AspNetCore.Identity;
using YourOSBB.Entities;

namespace YourOSBB.Infrastructure.Interfaces;

public interface IApplicationUserRepository : IRepository<ApplicationUser>
{
    public Task Update(ApplicationUser entity);
}