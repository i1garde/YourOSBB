namespace YourOSBB.Entities.VotingEntities;

public class Poll
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OsbbId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<PollCandidate> PollCandidates { get; set; }
    public DateTime Date { get; set; }

    public Poll()
    {
        
    }

    public Poll(string name, string description, ICollection<PollCandidate> pollCandidates)
    {
        Name = name;
        Description = description;
        PollCandidates = pollCandidates;
        Date = DateTime.Now;
    }
}