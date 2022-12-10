using AssayDatabaseAPI.Data;
using AssayDatabaseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssayDatabaseAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    // Action result gives access to standard http responses
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() // list of all users
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return user;
    }
}