namespace YourOSBB.Web.Models.Entities.VotingViewModels;

public class CompletedPollViewModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OsbbId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public PollCandidateViewModel WinnerPollCandidateViewModel { get; set; }
    public DateTime Date { get; set; }
}