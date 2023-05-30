using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using YourOSBB.Entities;
using YourOSBB.Services.Interfaces;
using YourOSBB.Web.Models.Entities;

namespace YourOSBB.Web.Controllers;

public class ComplaintController : Controller
{
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOsbbService _osbbService;
    private readonly IComplaintService _complaintService;
    private readonly IApplicationUserService _applicationUserService;

    public ComplaintController(IMapper mapper,
        UserManager<ApplicationUser> userManager,
        IOsbbService osbbService,
        IComplaintService complaintService,
        IApplicationUserService applicationUserService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _osbbService = osbbService;
        _complaintService = complaintService;
        _applicationUserService = applicationUserService;
    }
    
    [Authorize(Roles = "OsbbHead")]
    public async Task<IActionResult> ShowComplaintsToHead()
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var getComplaints = await _complaintService.GetAll();
        var complaints = getComplaints.Where(x => x.OsbbId == usr.OsbbId);
        
        if (complaints.IsNullOrEmpty())
        {
            return View("ToHeadNoComplaints");
        }
        
        return View("ToHeadComplaints", complaints
            .Select(x => _mapper.Map<Complaint, ComplaintViewModel>(x)).ToList());
    }
    
    [Authorize(Roles = "Resident")]
    public async Task<IActionResult> ShowComplaintsToResidents()
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var getComplaints = await _complaintService.GetAll();
        var complaints = getComplaints.Where(x => x.OsbbId == usr.OsbbId);
        
        if (complaints.IsNullOrEmpty())
        {
            return View("ToResidentsNoComplaints");
        }
        
        return View("ToResidentsComplaints", complaints
            .Select(x => _mapper.Map<Complaint, ComplaintViewModel>(x)).ToList());
    }
    
    [Authorize(Roles = "Resident")]
    [HttpGet]
    public IActionResult CreateComplaint()
    {
        return View("CreateComplaint");
    }
    
    [Authorize(Roles = "Resident")]
    [HttpPost]
    public async Task<IActionResult> CreateComplaint(ComplaintViewModel complaint)
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var osbbT = await _osbbService.GetAll();
        var osbb = osbbT.Where(x => x.OsbbId == usr.OsbbId).First();
        
        complaint.OsbbId = osbb.OsbbId;
        complaint.UserId = usr.Id;
        complaint.Date = DateTime.Now;
        

        await _complaintService.Add(_mapper.Map<ComplaintViewModel, Complaint>(complaint));
        
        return RedirectToAction("ShowComplaintsToResidents");
    }
}