using AssayDatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AssayDatabaseAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    // DB tables
    public DbSet<AppUser> Users { get; set; }
    
}