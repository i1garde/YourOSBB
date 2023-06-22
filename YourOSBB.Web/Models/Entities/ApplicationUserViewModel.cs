using Microsoft.AspNetCore.Identity;

namespace YourOSBB.Web.Models.Entities;

public class ApplicationUserViewModel
{
    public int Id { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string PatronymicName { get; set; }
    public string Role { get; set; }
    public int? OsbbId { get; set; } // Required foreign key property
    public OsbbViewModel? Osbb { get; set; }
}