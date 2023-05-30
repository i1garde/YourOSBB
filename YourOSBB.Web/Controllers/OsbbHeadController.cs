using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using YourOSBB.Entities;
using YourOSBB.Infrastructure;
using YourOSBB.Infrastructure.Repositories;
using YourOSBB.Services.Interfaces;
using YourOSBB.Web.Models.Entities;

namespace YourOSBB.Web.Controllers;

public class OsbbHeadController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOsbbService _osbbService;
    private readonly IApplicationUserService _applicationUserService;
    private readonly IAnnouncementService _announcementService;
    private readonly IMapper _mapper;

    public OsbbHeadController(IMapper mapper,
        UserManager<ApplicationUser> userManager,
        IOsbbService osbbService,
        IAnnouncementService announcementService,
        IApplicationUserService applicationUserService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _osbbService = osbbService;
        _announcementService = announcementService;
        _applicationUserService = applicationUserService;
    }
    
    // GET
    [Authorize(Roles = "OsbbHead")]
    public IActionResult OsbbHead()
    {
        return View();
    }
    
    [Authorize(Roles = "OsbbHead")]
    public async Task<IActionResult> Osbb()
    {
        var usr = await _userManager.GetUserAsync(HttpContext.User);
        var userOsbb = await _userManager.FindByEmailAsync(usr.Email);
        if (userOsbb.OsbbId == null)
        {
            return View("CreateOsbb");
        }

        var osbb = await _osbbService.GetById(userOsbb.OsbbId.Value);
        return View(_mapper.Map<Osbb, OsbbViewModel>(osbb));
    }
    
    [Authorize(Roles = "OsbbHead")]
    [HttpPost]
    public async Task<IActionResult> CreateOsbb(OsbbViewModel obj)
    {
        await _osbbService.Add(_mapper.Map<OsbbViewModel, Osbb>(obj));
        var usr = await _userManager.GetUserAsync(HttpContext.User);
        var userEnt = await _userManager.FindByEmailAsync(usr.Email);
        var osbbT = await _osbbService.GetAll();
        var osbb = osbbT.Where(x => x.Name == obj.Name).First();

        userEnt.OsbbId = osbb.OsbbId;
        userEnt.Osbb = osbb;
        await _userManager.UpdateAsync(userEnt);
        return RedirectToAction("Osbb");
    }
    
    [Authorize(Roles = "OsbbHead")]
    public IActionResult AnnouncementCreation()
    {
        return View();
    }
    
    [Authorize(Roles = "OsbbHead")]
    public async Task<IActionResult> ShowAnnouncements()
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var getAnnouncements = await _announcementService.GetAll();
        var announcements = getAnnouncements.Where(x => x.OsbbId == usr.OsbbId);
        
        if (announcements.IsNullOrEmpty())
        {
            return View("NoAnnouncements");
        }
        return View(announcements
            .Select(x => _mapper.Map<Announcement, AnnouncementViewModel>(x)).ToList());
    }
    
    [Authorize(Roles = "OsbbHead")]
    [HttpPost]
    public async Task<IActionResult> CreateAnnouncement(AnnouncementViewModel obj)
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var osbbT = await _osbbService.GetAll();
        var osbb = osbbT.Where(x => x.OsbbId == usr.OsbbId).First();
        
        obj.OsbbId = osbb.OsbbId;
        obj.UserId = usr.Id;
        obj.Date = DateTime.Now;
        

        await _announcementService.Add(_mapper.Map<AnnouncementViewModel, Announcement>(obj));
        
        return RedirectToAction("ShowAnnouncements");
    }
}