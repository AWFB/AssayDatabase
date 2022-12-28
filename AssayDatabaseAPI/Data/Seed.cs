using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using AssayDatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AssayDatabaseAPI.Data;

public class Seed
{
    public static async Task SeedData(DataContext context)
    {
        if (await context.Users.AnyAsync()) return;

        var seedDataFile = await File.ReadAllTextAsync("Data/seeddata.json");

        // in case of casing mismatch. 
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var users = JsonSerializer.Deserialize<List<AppUser>>(seedDataFile, options);

        foreach (var user in users)
        {
            using var hmac = new HMACSHA512();

            user.Email = user.Email.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password1!"));
            user.PasswordSalt = hmac.Key;

            context.Users.Add(user);
        }

        await context.SaveChangesAsync();
    }
}