namespace AssayDatabaseAPI.DTOs;

public class MemberDto
{
    public int Id { get; set; }
    public string UserName { get; set; } // Hospital/ lab name
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime Created { get; set; }
    public List<AssayDto> Assays { get; set; }
}