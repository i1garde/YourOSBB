using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;
using YourOSBB.Services.Interfaces;

namespace YourOSBB.Services;

public class ApplicationUserService : IApplicationUserService
{
    private IUnitOfWork _unitOfWork;
    
    public ApplicationUserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Add(ApplicationUser user)
    {
        await _unitOfWork.ApplicationUserManager.CreateAsync(user);
        await _unitOfWork.DoAsync();
    }

    public async Task Delete(ApplicationUser user)
    {
        await _unitOfWork.ApplicationUserManager.DeleteAsync(user);
        await _unitOfWork.DoAsync();
    }

    public async Task<ApplicationUser> GetById(int id)
    {
        return await _unitOfWork.ApplicationUserRepository.GetByIdAsync(id);
    }

    public async Task<ApplicationUser> GetById(string id)
    {
        return await _unitOfWork.ApplicationUserManager.FindByIdAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<ApplicationUser>> GetAll()
    {
        return await _unitOfWork.ApplicationUserRepository.GetAllAsync();
    }
    
    public UserManager<ApplicationUser> GetUserManager()
    {
        return _unitOfWork.ApplicationUserManager;
    }
}