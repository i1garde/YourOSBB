using YourOSBB.Entities.VotingEntities;

namespace YourOSBB.Services.Interfaces;

public interface IVotingService
{
    Task CreatePoll(Poll poll);
    Task<IEnumerable<Poll>> ShowActiveOsbbPolls(int osbbId);
    Task<IEnumerable<CompletedPoll>> ShowCompletedOsbbPolls(int osbbId);
    Task<Poll> GetPollById(int id);
    Task<PollCandidate> GetPollCandidateById(int id);
    Task<IEnumerable<PollCandidate>> GetManyPollCandidatesByPollId(int id);
    Task VoteForCandidate(int userId, PollCandidate pollCandidate);
}