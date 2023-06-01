namespace YourOSBB.Web.Models.Entities.VotingViewModels;

public class PollViewModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OsbbId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<PollCandidateViewModel> PollCandidates { get; set; }
    public DateTime Date { get; set; }

    public PollViewModel()
    {
        
    }

    public PollViewModel(string name, string description, ICollection<PollCandidateViewModel> pollCandidates)
    {
        Name = name;
        Description = description;
        PollCandidates = pollCandidates;
        Date = DateTime.Now;
    }
}