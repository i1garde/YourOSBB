
namespace YourOSBB.Entities;

public class Osbb
{
    public int OsbbId { get; set; }
    public string Name { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public ICollection<ApplicationUser> Residents { get; } = new List<ApplicationUser>();
    
    public Osbb()
    {
        
    }
    
    public Osbb(string name, string region, string city, string street, string houseNumber)
    {
        this.Name = name;
        this.Region = region;
        this.City = city;
        this.Street = street;
        this.HouseNumber = houseNumber;
    }
}