namespace AssayDatabaseAPI.DTOs;

public class AssayDto
{
    public int Id { get; set; }
    public string NameOfTest { get; set; }
    public string TestNameAlias { get; set; } //TODO: figure out a cleaner way of storing multiple names
    public string AddressLineOne { get; set; }
    public string AddressLineTwo { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string Country { get; set; }
    public string PostCode { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string ContactName { get; set; }
    public string SampleType { get; set; }
    public string SampleVolume { get; set; }
    public string StorageConditions { get; set; }
    public string TransportConditions { get; set; }
    public bool NpexSupport { get; set; }
    public string AutoComment { get; set; }
    public string TurnAroundTime { get; set; }
    public bool UkasAccredited { get; set; }
    public string AccreditationNumber { get; set; }
    public bool EqaScheme { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
    public string Comments { get; set; }
}