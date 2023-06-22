using System.Xml;
using YourOSBB.Entities.VotingEntities;
using YourOSBB.Infrastructure.Interfaces;
using YourOSBB.Services.Interfaces;

namespace YourOSBB.Services;

public class VotingService : IVotingService
{
    private IUnitOfWork _unitOfWork;

    public VotingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task CreatePoll(Poll poll)
    {
        await _unitOfWork.PollRepository.AddAsync(poll);
        await _unitOfWork.DoAsync();
    }

    public async Task DeletePoll(Poll poll)
    {
        await _unitOfWork.PollRepository.DeleteAsync(poll);
        await _unitOfWork.DoAsync();
    }

    public async Task<IEnumerable<Poll>> ShowActiveOsbbPolls(int osbbId)
    {
        var fetch = await _unitOfWork.PollRepository.GetAllAsync();
        return fetch.Where(x => x.OsbbId == osbbId);
    }
    
    public async Task<IEnumerable<Poll>> GetNoVotedPollsForUser(int userId)
    {
        var usr = await _unitOfWork.ApplicationUserRepository.GetByIdAsync(userId);
        var allPoles = await ShowActiveOsbbPolls(usr.OsbbId.Value);
        
        var notVotedPolls = allPoles
            .SelectMany(x => allPoles)
            .GroupBy(x => x.Id)
            .Select(x => x.First())
            .ToList();

        return notVotedPolls;
    }
    
    public async Task<IEnumerable<Poll>> GetAlreadyVotedPollsForUser(int pollId, int userId)
    {
        var votes = await _unitOfWork.UserVoteRepository.GetAllAsync();
        var userVotes = votes.Where(x => x.PollId == pollId && x.UserId == userId)
            .Select(x => _unitOfWork.PollRepository.GetByIdAsync(x.PollId).Result);
        
        return userVotes;
    }
    
    public async Task<IEnumerable<CompletedPoll>> ShowCompletedOsbbPolls(int osbbId)
    {
        var fetch = await _unitOfWork.CompletedPollRepository.GetAllAsync();
        return fetch.Where(x => x.OsbbId == osbbId);
    }
    
    public async Task<Poll> GetPollById(int id)
    {
        return await _unitOfWork.PollRepository.GetByIdAsync(id);
    }
    
    public async Task<PollCandidate> GetPollCandidateById(int id)
    {
        return await _unitOfWork.PollCandidateRepository.GetByIdAsync(id);
    }
    
    public async Task<IEnumerable<PollCandidate>> GetManyPollCandidatesByPollId(int id)
    {
        var temp = await _unitOfWork.PollCandidateRepository.GetAllAsync();
        return temp.Where(x => x.PollId == id).ToList();
    }
    
    public async Task VoteForCandidate(int userId, PollCandidate pollCandidate)
    {
        await _unitOfWork.UserVoteRepository
            .AddAsync(new UserVote
            {
                UserId = userId, 
                PollCandidateId = pollCandidate.Id, 
                PollCandidate = pollCandidate,
                PollId = pollCandidate.PollId
            });
        await _unitOfWork.DoAsync();
    }

    public async Task<IEnumerable<UserVote>> GetAllUserVotes()
    {
        return await _unitOfWork.UserVoteRepository.GetAllAsync();
    }
    
    public async Task<PollCandidate?> GetPollWinner(int pollId)
    {
        var pollCandidates = await GetManyPollCandidatesByPollId(pollId);
        var countIt = pollCandidates.Select(x =>
            (x, GetAllUserVotes().Result.Where(y => y.PollCandidateId == x.Id).Count()));
        
        var ordered = from i in countIt
            orderby i.Item2 descending
            select i;

        var checkLogic = ordered.Take(2).Select(x => x.Item2).Aggregate((x, y) => x - y) == 0
            ? null
            : ordered.First().Item1;
        
        return checkLogic;
    }
    
    public async Task CreateCompletedPoll(CompletedPoll poll)
    {
        await _unitOfWork.CompletedPollRepository.AddAsync(poll);
        await _unitOfWork.DoAsync();
    }
    
    public async Task<IEnumerable<CompletedPoll>> GetAllCompletedPollsByOsbb(int osbbId)
    {
        var fetch = await _unitOfWork.CompletedPollRepository.GetAllAsync();
        return fetch.Where(x => x.OsbbId == osbbId);
    }
}