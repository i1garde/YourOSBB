namespace YourOSBB.Entities.VotingEntities;

public class UserVote
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PollCandidateId { get; set; }
    public int PollId { get; set; }
    public PollCandidate PollCandidate { get; set; }
}