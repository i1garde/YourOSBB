using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using YourOSBB.Entities;
using YourOSBB.Entities.VotingEntities;
using YourOSBB.Services.Interfaces;
using YourOSBB.Web.Models.Entities;
using YourOSBB.Web.Models.Entities.VotingViewModels;

namespace YourOSBB.Web.Controllers;

public class VotingController : Controller
{
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOsbbService _osbbService;
    private readonly IVotingService _votingService;
    private readonly IApplicationUserService _applicationUserService;

    public VotingController(IMapper mapper,
        UserManager<ApplicationUser> userManager,
        IOsbbService osbbService,
        IVotingService votingService,
        IApplicationUserService applicationUserService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _osbbService = osbbService;
        _votingService = votingService;
        _applicationUserService = applicationUserService;
    }
    
    [Authorize(Roles = "OsbbHead")]
    public async Task<IActionResult> ShowVotingToHead()
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var getPolls = await _votingService.ShowActiveOsbbPolls(usr.OsbbId.Value);
        
        if (getPolls.IsNullOrEmpty())
        {
            return View("ToHeadNoPolls");
        }
        
        return View("ToHeadPolls", getPolls
            .Select(x => _mapper.Map<Poll, PollViewModel>(x)).ToList());
    }
    
    [Authorize(Roles = "Resident")]
    public async Task<IActionResult> ShowVotingToResidents()
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var getPolls = await _votingService.ShowActiveOsbbPolls(usr.OsbbId.Value);
        
        if (getPolls.IsNullOrEmpty())
        {
            return View("ToResidentsNoPolls");
        }
        
        return View("ToResidentsPolls", getPolls
            .Select(x => _mapper.Map<Poll, PollViewModel>(x)).ToList());
    }
    
    [Authorize(Roles = "OsbbHead")]
    [HttpGet]
    public async Task<IActionResult> CreatePoll()
    {
        return View("CreatePoll");
    }
    
    [Authorize(Roles = "OsbbHead")]
    [HttpPost]
    public async Task<IActionResult> CreatePoll(PollWithCandidatesViewModel poll)
    {
        var pollName = poll.Name;
        var pollDesc = poll.Description;
        var listOfCandidates = poll.Candidate
            .Select(x => _mapper.Map<PollCandidateViewModel, PollCandidate>(x))
            .ToList();
        var readyPoll = new Poll(pollName, pollDesc, listOfCandidates);
        
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        
        readyPoll.Date = DateTime.Now;
        readyPoll.UserId = usr.Id;
        readyPoll.OsbbId = usr.OsbbId.Value;
        
        await _votingService.CreatePoll(readyPoll);
        
        return RedirectToAction("ShowVotingToHead");
    }
    
    [Authorize(Roles = "OsbbHead")]
    [HttpGet]
    public async Task<IActionResult> HeadVote(string pollId)
    {
        var poll = await _votingService.GetPollById(Convert.ToInt32(pollId));
        ViewBag.PollName = poll.Name;
        ViewBag.PollDescription = poll.Description;
        var pollCandidates = await _votingService.GetManyPollCandidatesByPollId(poll.Id);
        ViewBag.PollCandidatesIdName = pollCandidates.Select(x => (x.Id, x.Name)).ToList();
        
        return View("ToHeadSelectedPoll");
    }
    
    [Authorize(Roles = "Resident")]
    [HttpGet]
    public async Task<IActionResult> ResidentVote(string pollId)
    {
        var poll = await _votingService.GetPollById(Convert.ToInt32(pollId));
        ViewBag.PollName = poll.Name;
        ViewBag.PollDescription = poll.Description;
        var pollCandidates = await _votingService.GetManyPollCandidatesByPollId(poll.Id);
        ViewBag.PollCandidatesIdName = pollCandidates.Select(x => (x.Id, x.Name)).ToList();
        
        return View("ToResidentSelectedPoll");
    }
    
    [Authorize(Roles = "OsbbHead")]
    [HttpPost]
    public async Task<IActionResult> HeadVoteForCandidate(string pollCandidateId)
    {
        var pollCandId = Convert.ToInt32(pollCandidateId);
        
        Console.WriteLine($"DEBUGGG: {pollCandId}");
        
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);

        var pollCand = await _votingService.GetPollCandidateById(pollCandId);

        await _votingService.VoteForCandidate(usr.Id, pollCand);
        
        return RedirectToAction("ShowVotingToHead");
    }
    
    [Authorize(Roles = "Resident")]
    [HttpPost]
    public async Task<IActionResult> ResidentVoteForCandidate(string pollCandidateId)
    {
        var pollCandId = Convert.ToInt32(pollCandidateId);
        
        Console.WriteLine($"DEBUGGG: {pollCandId}");
        
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);

        var pollCand = await _votingService.GetPollCandidateById(pollCandId);

        await _votingService.VoteForCandidate(usr.Id, pollCand);
        
        return RedirectToAction("ShowVotingToResidents");
    }
}