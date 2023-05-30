namespace YourOSBB.Web.Models.Entities;

public class ProposalViewModel
{
    public int ProposalId { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public int OsbbId { get; set; }
} 