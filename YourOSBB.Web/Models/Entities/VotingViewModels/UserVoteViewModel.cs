namespace YourOSBB.Web.Models.Entities.VotingViewModels;

public class UserVoteViewModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PollCandidateId { get; set; }
    public PollCandidateViewModel PollCandidateViewModel { get; set; }
}