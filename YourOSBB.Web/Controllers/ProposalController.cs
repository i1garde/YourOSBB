using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using YourOSBB.Entities;
using YourOSBB.Infrastructure.Interfaces;
using YourOSBB.Services.Interfaces;
using YourOSBB.Web.Models.Entities;

namespace YourOSBB.Web.Controllers;

public class ProposalController : Controller
{
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOsbbService _osbbService;
    private readonly IProposalService _proposalService;
    private readonly IApplicationUserService _applicationUserService;

    public ProposalController(IMapper mapper,
        UserManager<ApplicationUser> userManager,
        IOsbbService osbbService,
        IProposalService proposalService,
        IApplicationUserService applicationUserService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _osbbService = osbbService;
        _proposalService = proposalService;
        _applicationUserService = applicationUserService;
    }
    
    [Authorize(Roles = "OsbbHead")]
    public async Task<IActionResult> ShowProposalsToHead()
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var getProposals = await _proposalService.GetAll();
        var proposals = getProposals.Where(x => x.OsbbId == usr.OsbbId);
        var getUsr = async (Proposal x) => await _applicationUserService.GetById(x.UserId);
        
        if (proposals.IsNullOrEmpty())
        {
            return View("ToHeadNoProposals");
        }
        
        return View("ToHeadProposals", proposals
            .Select(x => (_mapper.Map<Proposal, ProposalViewModel>(x), getUsr(x).Result)));
    }
    
    [Authorize(Roles = "Resident")]
    public async Task<IActionResult> ShowProposalsToResidents()
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var getProposals = await _proposalService.GetAll();
        var proposals = getProposals.Where(x => x.OsbbId == usr.OsbbId);
        var getUsr = async (Proposal x) => await _applicationUserService.GetById(x.UserId);
        
        if (proposals.IsNullOrEmpty())
        {
            return View("ToResidentsNoProposals");
        }

        ViewBag.userProposals = proposals.Where(x => x.UserId == usr.Id);
        
        return View("ToResidentsProposals", proposals
            .Select(x => (_mapper.Map<Proposal, ProposalViewModel>(x), getUsr(x).Result)));
    }
    
    [Authorize(Roles = "Resident, OsbbHead")]
    [HttpGet]
    public IActionResult CreateProposal()
    {
        return View("CreateProposal");
    }
    
    [Authorize(Roles = "Resident, OsbbHead")]
    [HttpPost]
    public async Task<IActionResult> CreateProposal(ProposalViewModel proposal)
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var osbbT = await _osbbService.GetAll();
        var osbb = osbbT.Where(x => x.OsbbId == usr.OsbbId).First();
        
        proposal.OsbbId = osbb.OsbbId;
        proposal.UserId = usr.Id;
        proposal.Date = DateTime.Now;
        

        await _proposalService.Add(_mapper.Map<ProposalViewModel, Proposal>(proposal));

        return RedirectToAction("ShowProposalsToResidents");
    } 
        
    [Authorize(Roles = "Resident")]
    [HttpGet]
    public async Task<IActionResult> UpdateProposal(string propId)
    {
        int id = Convert.ToInt32(propId);
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var prop = await _proposalService.GetById(id);
        ViewBag.ProposalId = id;
        ViewBag.OsbbId = usr.OsbbId;
        ViewBag.UserId = usr.Id;
        return View("ChangeProposal", _mapper.Map<Proposal, ProposalViewModel>(prop));
    }
        
    [Authorize(Roles = "Resident")]
    [HttpPost]
    public async Task<IActionResult> UpdateProposalPost(ProposalViewModel obj)
    {
        await _proposalService.Update(_mapper.Map<ProposalViewModel, Proposal>(obj));
        
        return RedirectToAction("ShowProposalsToResidents");
    }
    
    [Authorize(Roles = "Resident")]
    [HttpPost]
    public async Task<IActionResult> DeleteProposal(string proposalId)
    {
        int id = Convert.ToInt32(proposalId);
        var tar = await _proposalService.GetById(id);
        await _proposalService.Delete(tar);
        
        return RedirectToAction("ShowProposalsToResidents");
    }
}