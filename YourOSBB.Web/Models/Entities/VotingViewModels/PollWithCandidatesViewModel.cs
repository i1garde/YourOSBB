namespace YourOSBB.Web.Models.Entities.VotingViewModels;

public class PollWithCandidatesViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<PollCandidateViewModel> Candidate { get; set; }
}