namespace YourOSBB.Web.Models.Entities;

public class ComplaintViewModel
{
    public int ComplaintId { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public int OsbbId { get; set; }
}