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
        
        if (proposals.IsNullOrEmpty())
        {
            return View("ToHeadNoProposals");
        }
        
        return View("ToHeadProposals", proposals
            .Select(x => _mapper.Map<Proposal, ProposalViewModel>(x)).ToList());
    }
    
    [Authorize(Roles = "Resident")]
    public async Task<IActionResult> ShowProposalsToResidents()
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var getProposals = await _proposalService.GetAll();
        var proposals = getProposals.Where(x => x.OsbbId == usr.OsbbId);
        
        if (proposals.IsNullOrEmpty())
        {
            return View("ToResidentsNoProposals");
        }
        
        return View("ToResidentsProposals", proposals
            .Select(x => _mapper.Map<Proposal, ProposalViewModel>(x)).ToList());
    }
    
    [Authorize(Roles = "Resident")]
    [HttpGet]
    public IActionResult CreateProposal()
    {
        return View("CreateProposal");
    }
    
    [Authorize(Roles = "Resident")]
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
}