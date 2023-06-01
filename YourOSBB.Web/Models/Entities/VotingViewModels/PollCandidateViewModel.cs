namespace YourOSBB.Web.Models.Entities.VotingViewModels;

public class PollCandidateViewModel
{
    public int Id { get; set; }
    public int PollId { get; set; }
    public PollViewModel PollViewModel { get; set; }
    public string Name { get; set; }
    public ICollection<UserVoteViewModel> UserVotes { get; set; }

    public PollCandidateViewModel()
    {
        
    }

    public PollCandidateViewModel(string name)
    {
        Name = name;
        UserVotes = new List<UserVoteViewModel>();
    }
}