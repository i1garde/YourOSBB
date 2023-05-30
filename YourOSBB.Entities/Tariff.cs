namespace YourOSBB.Entities;

public class Tariff
{
    public int TariffId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
    public int UserId { get; set; }
    public int OsbbId { get; set; }
}