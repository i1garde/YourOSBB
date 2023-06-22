using YourOSBB.Entities.VotingEntities;

namespace YourOSBB.Services.Interfaces;

public interface IVotingService
{
    Task CreatePoll(Poll poll);
    Task DeletePoll(Poll poll);
    Task<IEnumerable<Poll>> ShowActiveOsbbPolls(int osbbId);
    Task<IEnumerable<CompletedPoll>> ShowCompletedOsbbPolls(int osbbId);
    Task<Poll> GetPollById(int id);
    Task<PollCandidate> GetPollCandidateById(int id);
    Task<IEnumerable<PollCandidate>> GetManyPollCandidatesByPollId(int id);
    Task VoteForCandidate(int userId, PollCandidate pollCandidate);
    Task<IEnumerable<Poll>> GetNoVotedPollsForUser(int userId);
    Task<IEnumerable<Poll>> GetAlreadyVotedPollsForUser(int pollId, int userId);
    Task<IEnumerable<UserVote>> GetAllUserVotes();
    Task<PollCandidate?> GetPollWinner(int pollId);
    Task CreateCompletedPoll(CompletedPoll poll);
    Task<IEnumerable<CompletedPoll>> GetAllCompletedPollsByOsbb(int osbbId);
}