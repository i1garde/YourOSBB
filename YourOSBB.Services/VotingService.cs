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
    
    public async Task<IEnumerable<Poll>> ShowActiveOsbbPolls(int osbbId)
    {
        var fetch = await _unitOfWork.PollRepository.GetAllAsync();
        return fetch.Where(x => x.OsbbId == osbbId);
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
                PollCandidate = pollCandidate
            });
        await _unitOfWork.DoAsync();
    }
}