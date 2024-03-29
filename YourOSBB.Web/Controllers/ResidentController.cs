﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using YourOSBB.Entities;
using YourOSBB.Infrastructure;
using YourOSBB.Services.Interfaces;
using YourOSBB.Web.Models.Entities;

namespace YourOSBB.Web.Controllers;

public class ResidentController : Controller
{
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOsbbService _osbbService;
    private readonly IAnnouncementService _announcementService;
    private readonly IApplicationUserService _applicationUserService;

    public ResidentController(IMapper mapper,
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
    [Authorize(Roles = "Resident")]
    public async Task<IActionResult> Resident()
    {
        var usr = await _userManager.GetUserAsync(HttpContext.User);
        ViewBag.Surname = usr.Surname;
        ViewBag.Name = usr.Name;
        ViewBag.PatronymicName = usr.PatronymicName;
        ViewBag.UserEmail = usr.Email;
        return View(_mapper.Map<ApplicationUser, ApplicationUserViewModel>(usr));
    }
    
    [Authorize(Roles = "Resident")]
    public async Task<IActionResult> Osbb()
    {
        var usr = await _userManager.GetUserAsync(HttpContext.User);
        var userOsbb = await _userManager.FindByEmailAsync(usr.Email);
        if (userOsbb.OsbbId == null)
        {
            return View("OsbbNotFound");
        }
        var osbb = await _osbbService.GetById(userOsbb.OsbbId.Value);
        var osbbHead = await _osbbService.ReturnOsbbHead(osbb.OsbbId);
        ViewBag.OsbbHeadName = $"{osbbHead.Surname} {osbbHead.Name} {osbbHead.PatronymicName}";
        ViewBag.OsbbHeadEmail = osbbHead.Email;
        
        return View(_mapper.Map<Osbb, OsbbViewModel>(osbb));
    }
    
    [Authorize(Roles = "Resident")]
    [HttpPost]
    public async Task<IActionResult> ConnectToOsbb(NameRecordViewModel osbbName)
    {
        var osbbT = await _osbbService.GetAll();
        var osbbFetch = osbbT.Where(x => x.Name == osbbName.Name);

        if(osbbFetch.IsNullOrEmpty())
        {
            return RedirectToAction("OsbbNotExistError");
        } else
        {
            var osbb = osbbFetch.First();

            var usr = await _userManager.GetUserAsync(HttpContext.User);

            osbb.Residents.Add(usr);
            await _osbbService.Update(osbb);

            usr.OsbbId = osbb.OsbbId;
            usr.Osbb = osbb;
            await _userManager.UpdateAsync(usr);

            return RedirectToAction("Osbb");
        }
    }
    
    [Authorize(Roles = "Resident")]
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

    [Authorize(Roles = "Resident")]
    [HttpGet]
    public async Task<IActionResult> OsbbNotExistError()
    {
        return View();
    }
}