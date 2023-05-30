using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using YourOSBB.Entities;
using YourOSBB.Services.Interfaces;
using YourOSBB.Web.Models.Entities;

namespace YourOSBB.Web.Controllers;

public class TariffController : Controller
{
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOsbbService _osbbService;
    private readonly ITariffService _tariffService;
    private readonly IApplicationUserService _applicationUserService;

    public TariffController(IMapper mapper,
        UserManager<ApplicationUser> userManager,
        IOsbbService osbbService,
        ITariffService tariffService,
        IApplicationUserService applicationUserService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _osbbService = osbbService;
        _tariffService = tariffService;
        _applicationUserService = applicationUserService;
    }
    
    [Authorize(Roles = "OsbbHead")]
    public async Task<IActionResult> ShowTariffsToHead()
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var getTariffs = await _tariffService.GetAll();
        var tariffs = getTariffs.Where(x => x.OsbbId == usr.OsbbId);
        
        if (tariffs.IsNullOrEmpty())
        {
            return View("ToHeadNoTariffs");
        }
        
        return View("ToHeadTariffs", tariffs
            .Select(x => _mapper.Map<Tariff, TariffViewModel>(x)).ToList());
    }
    
    [Authorize(Roles = "Resident")]
    public async Task<IActionResult> ShowTariffsToResidents()
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var getTariffs = await _tariffService.GetAll();
        var tariffs = getTariffs.Where(x => x.OsbbId == usr.OsbbId)
            .Where(x => x.UserId == usr.Id);
        
        if (tariffs.IsNullOrEmpty())
        {
            return View("ToResidentsNoTariffs");
        }
        
        return View("ToResidentsTariffs", tariffs
            .Select(x => _mapper.Map<Tariff, TariffViewModel>(x)).ToList());
    }
    
    [Authorize(Roles = "OsbbHead")]
    [HttpGet]
    public async Task<IActionResult> CreateTariff()
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var osbbT = await _osbbService.GetAll();
        var osbb = osbbT.Where(x => x.OsbbId == usr.OsbbId).First();
        
        var users = await _applicationUserService.GetAll();
        var list = new List<SelectListItem>();
        foreach (var u in users.Where(x => x.OsbbId == osbb.OsbbId))
        {
            list.Add(new SelectListItem
            {
                Value = u.Id.ToString(), Text = $"{u.Surname} {u.Name}"
            });
        }

        ViewBag.UsersList = list;
        return View("CreateTariff");
    }
    
    [Authorize(Roles = "OsbbHead")]
    [HttpPost]
    public async Task<IActionResult> CreateTariff(TariffAndUserIdViewModel tariffAndUserId)
    {
        var usr = await _applicationUserService.GetById(Convert.ToInt32(tariffAndUserId.UserId));
        var osbbT = await _osbbService.GetAll();
        var osbb = osbbT.Where(x => x.OsbbId == usr.OsbbId).First();
        
        tariffAndUserId.Tariff.OsbbId = osbb.OsbbId;
        tariffAndUserId.Tariff.UserId = usr.Id;

        await _tariffService.Add(_mapper.Map<TariffViewModel, Tariff>(tariffAndUserId.Tariff));
        
        return RedirectToAction("ShowTariffsToHead");
    }
}