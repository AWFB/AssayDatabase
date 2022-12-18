using System.ComponentModel.DataAnnotations;

namespace AssayDatabaseAPI.DTOs;

public class RegisterDto
{
    [Required] public string Username { get; set; }
    
    [Required] 
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [StringLength(12, MinimumLength = 6)]
    public string Password { get; set; }
}