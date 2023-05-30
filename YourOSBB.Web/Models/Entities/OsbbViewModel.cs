
namespace YourOSBB.Web.Models.Entities;

public class OsbbViewModel
{
    public int OsbbId { get; set; }
    public string Name { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public ICollection<ApplicationUserViewModel> Residents { get; } = new List<ApplicationUserViewModel>();
    
    public OsbbViewModel()
    {
        
    }
    
    public OsbbViewModel(string name, string region, string city, string street, string houseNumber)
    {
        this.Name = name;
        this.Region = region;
        this.City = city;
        this.Street = street;
        this.HouseNumber = houseNumber;
    }
}