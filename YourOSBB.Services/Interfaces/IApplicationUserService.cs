using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using YourOSBB.Entities;

namespace YourOSBB.Services.Interfaces;

public interface IApplicationUserService
{
    Task Add(ApplicationUser user);
    Task Delete(ApplicationUser user);
    Task<ApplicationUser> GetById(int id);
    Task<IEnumerable<ApplicationUser>> GetAll();
    UserManager<ApplicationUser> GetUserManager();
}