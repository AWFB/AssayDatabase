using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AssayDatabaseAPI.Interfaces;
using AssayDatabaseAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace AssayDatabaseAPI.Services;

public class TokenService : ITokenService
{
    // symmetric key used for crypting/decrypting
    // asymetric private key and public key
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration config)
    {
        // get key from env variables
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
    }
    
    public string CreateToken(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}