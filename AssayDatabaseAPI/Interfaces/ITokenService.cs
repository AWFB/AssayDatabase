using AssayDatabaseAPI.Models;

namespace AssayDatabaseAPI.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
    
}