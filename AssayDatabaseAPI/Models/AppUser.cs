namespace AssayDatabaseAPI.Models;

public class AppUser
{
    public int Id { get; set; }
    public string UserName { get; set; } // Hospital/ lab name
    public string FullName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public List<Assay> Assays { get; set; } = new();
}