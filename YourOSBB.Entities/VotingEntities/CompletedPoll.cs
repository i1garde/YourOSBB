namespace YourOSBB.Entities.VotingEntities;

public class CompletedPoll
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OsbbId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public PollCandidate WinnerPollCandidate { get; set; }
    public DateTime Date { get; set; }
}