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
        var getUsr = async (Complaint x) => await _applicationUserService.GetById(x.UserId);
        
        if (complaints.IsNullOrEmpty())
        {
            return View("ToHeadNoComplaints");
        }
        
        return View("ToHeadComplaints", complaints
            .Select(x => (_mapper.Map<Complaint, ComplaintViewModel>(x), getUsr(x).Result)));
    }
    
    [Authorize(Roles = "Resident")]
    public async Task<IActionResult> ShowComplaintsToResidents()
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var getComplaints = await _complaintService.GetAll();
        var complaints = getComplaints.Where(x => x.OsbbId == usr.OsbbId);
        var getUsr = async (Complaint x) => await _applicationUserService.GetById(x.UserId);
        
        if (complaints.IsNullOrEmpty())
        {
            return View("ToResidentsNoComplaints");
        }

        ViewBag.userComplaints = complaints.Where(x => x.UserId == usr.Id);
        
        return View("ToResidentsComplaints", complaints
            .Select(x => (_mapper.Map<Complaint, ComplaintViewModel>(x), getUsr(x).Result)));
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
        
    [Authorize(Roles = "Resident")]
    [HttpGet]
    public async Task<IActionResult> UpdateComplaint(string compId)
    {
        int id = Convert.ToInt32(compId);
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var comp = await _complaintService.GetById(id);
        ViewBag.ComplaintId = id;
        ViewBag.OsbbId = usr.OsbbId;
        ViewBag.UserId = usr.Id;
        return View("ChangeComplaint", _mapper.Map<Complaint, ComplaintViewModel>(comp));
    }
        
    [Authorize(Roles = "Resident")]
    [HttpPost]
    public async Task<IActionResult> UpdateComplaintPost(ComplaintViewModel obj)
    {
        await _complaintService.Update(_mapper.Map<ComplaintViewModel, Complaint>(obj));
        
        return RedirectToAction("ShowComplaintsToResidents");
    }
    
    [Authorize(Roles = "Resident")]
    [HttpPost]
    public async Task<IActionResult> DeleteComplaint(string complaintId)
    {
        int id = Convert.ToInt32(complaintId);
        var tar = await _complaintService.GetById(id);
        await _complaintService.Delete(tar);
        
        return RedirectToAction("ShowComplaintsToResidents");
    }
}