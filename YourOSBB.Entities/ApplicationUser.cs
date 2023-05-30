using System;
using Microsoft.AspNetCore.Identity;

namespace YourOSBB.Entities;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser<int>
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string PatronymicName { get; set; }
    public string Role { get; set; }
    public int? OsbbId { get; set; } // Required foreign key property
    public Osbb? Osbb { get; set; }
}

