using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace YourOSBB.Web.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string PatronymicName { get; set; }
    public string Role { get; set; }
}

