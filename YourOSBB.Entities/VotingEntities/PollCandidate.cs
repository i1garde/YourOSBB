namespace YourOSBB.Entities.VotingEntities;

public class PollCandidate
{
    public int Id { get; set; }
    public int PollId { get; set; }
    public Poll Poll { get; set; }
    public string Name { get; set; }
    public ICollection<UserVote> UserVotes { get; set; }

    public PollCandidate()
    {
        
    }

    public PollCandidate(string name)
    {
        Name = name;
        UserVotes = new List<UserVote>();
    }
}