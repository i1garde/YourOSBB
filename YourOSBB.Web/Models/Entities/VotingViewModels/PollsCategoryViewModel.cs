using YourOSBB.Entities.VotingEntities;

namespace YourOSBB.Web.Models.Entities.VotingViewModels;

public class PollsCategoryViewModel
{
    public List<VotedPoll?> votedPoll { get; set; }
    public List<PollViewModel?> notVotedPoll { get; set; }
    public IEnumerable<CompletedPollViewModel> completedPoll { get; set; }
}

public class VotedPoll
{
    public PollViewModel poll { get; set; }
    public Canditate canditate { get; set; }
}

public class Canditate
{
    public IEnumerable<(PollCandidate, int)> PollCandidate { get; set; }
}