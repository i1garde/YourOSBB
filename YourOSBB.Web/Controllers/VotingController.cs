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
        var notVotedPolls = await _votingService.GetNoVotedPollsForUser(usr.Id);
        var votedPolls = getPolls
            .SelectMany(x => _votingService.GetAlreadyVotedPollsForUser(x.Id, usr.Id).Result)
            .GroupBy(x => x.Id)
            .Select(x => x.First())
            .ToList();

        var noVoteRes = notVotedPolls
            .Select(x => x.Id)
            .Except(votedPolls.Select(x => x.Id))
            .Select(x => _votingService.GetPollById(x).Result);

        var compPoll = await _votingService.GetAllCompletedPollsByOsbb(usr.OsbbId.Value);

        var pollViewModel = new PollsCategoryViewModel()
        {
            notVotedPoll = noVoteRes.Select(x => _mapper.Map<Poll, PollViewModel>(x)).ToList(),
            votedPoll = votedPolls
                .Select(x => new VotedPoll() { 
                    poll = _mapper.Map<Poll, PollViewModel>(x), 
                    canditate = new Canditate()
                    {
                        PollCandidate = _votingService.GetManyPollCandidatesByPollId(x.Id)
                            .Result
                            .Select(x => (x, _votingService.GetAllUserVotes().Result.Where(y => y.PollCandidateId == x.Id).Count()))
                    }
                })
                .ToList(),
            completedPoll = compPoll.Select(x => new CompletedPollViewModel()
            {
                Date = x.Date, Description = x.Description, Name = x.Name, WinnerPollCandidate = x.WinnerPollCandidateName
            })
        };
        
        if (getPolls.IsNullOrEmpty())
        {
            return View("ToHeadNoPolls");
        }
        
        return View("ToHeadPolls", pollViewModel);
    }
    
    [Authorize(Roles = "Resident")]
    public async Task<IActionResult> ShowVotingToResidents()
    {
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);
        var getPolls = await _votingService.ShowActiveOsbbPolls(usr.OsbbId.Value);
        var notVotedPolls = await _votingService.GetNoVotedPollsForUser(usr.Id);
        var votedPolls = getPolls
            .SelectMany(x => _votingService.GetAlreadyVotedPollsForUser(x.Id, usr.Id).Result)
            .GroupBy(x => x.Id)
            .Select(x => x.First())
            .ToList();

        var noVoteRes = notVotedPolls
            .Select(x => x.Id)
            .Except(votedPolls.Select(x => x.Id))
            .Select(x => _votingService.GetPollById(x).Result);
        
        var compPoll = await _votingService.GetAllCompletedPollsByOsbb(usr.OsbbId.Value);

        var pollViewModel = new PollsCategoryViewModel()
        {
            notVotedPoll = noVoteRes.Select(x => _mapper.Map<Poll, PollViewModel>(x)).ToList(),
            votedPoll = votedPolls
                .Select(x => new VotedPoll() { 
                    poll = _mapper.Map<Poll, PollViewModel>(x), 
                    canditate = new Canditate()
                    {
                        PollCandidate = _votingService.GetManyPollCandidatesByPollId(x.Id)
                            .Result
                            .Select(x => (x, _votingService.GetAllUserVotes().Result.Where(y => y.PollCandidateId == x.Id).Count()))
                    }
                })
                .ToList(),
            completedPoll = compPoll.Select(x => new CompletedPollViewModel()
            {
                Date = x.Date, Description = x.Description, Name = x.Name, WinnerPollCandidate = x.WinnerPollCandidateName
            })
        };
        
        if (getPolls.IsNullOrEmpty())
        {
            return View("ToResidentsNoPolls");
        }
        
        return View("ToResidentsPolls", pollViewModel);
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
        
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);

        var pollCand = await _votingService.GetPollCandidateById(pollCandId);

        await _votingService.VoteForCandidate(usr.Id, pollCand);
        
        return RedirectToAction("ShowVotingToResidents");
    }
        
    [Authorize(Roles = "OsbbHead")]
    [HttpGet]
    public async Task<IActionResult> CompletePoll(string pollId)
    {
        var pollCandId = Convert.ToInt32(pollId);
        
        var usr = await _applicationUserService.GetUserManager().GetUserAsync(HttpContext.User);

        var pollCand = await _votingService.GetPollWinner(pollCandId);

        if (pollCand == null)
        {
            //Can't complete poll
            return View("CompletedPollErrorPage");
        }
        else
        {
            //Delete poll and create poll completed
            var poll = await _votingService.GetPollById(pollCandId);
            var pollCompleted = new CompletedPoll()
            {
                Date = poll.Date,
                Description = poll.Description,
                Name = poll.Name,
                OsbbId = poll.OsbbId,
                UserId = poll.UserId,
                WinnerPollCandidateName = pollCand.Name
            };
            await _votingService.CreateCompletedPoll(pollCompleted);
            await _votingService.DeletePoll(poll);
            
            return RedirectToAction("ShowVotingToHead");
        }
    }
    
    [Authorize(Roles = "OsbbHead")]
    [HttpPost]
    public async Task<IActionResult> DeletePoll(string pollId)
    {
        int id = Convert.ToInt32(pollId);
        var tar = await _votingService.GetPollById(id);
        await _votingService.DeletePoll(tar);
        
        return RedirectToAction("ShowVotingToHead");
    }
}