using Microsoft.AspNetCore.Identity;

namespace YourOSBB.Entities;

public class ApplicationRole : IdentityRole<int>
{
    public ApplicationRole() : base()
    {
    }
    public ApplicationRole(string roleName)
    {
        Name = roleName;
    }
}