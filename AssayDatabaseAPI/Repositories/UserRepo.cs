using AssayDatabaseAPI.Data;
using AssayDatabaseAPI.DTOs;
using AssayDatabaseAPI.Interfaces;
using AssayDatabaseAPI.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AssayDatabaseAPI.Repositories;

public class UserRepo : IUserRepo
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserRepo(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public void Update(AppUser user)
    {
        _context.Entry(user).State = EntityState.Modified; // add to EF tracker
    }

    public async Task<bool> SaveAllAsync()
    {
        // returns number of changes saved
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await _context.Users
            .Include(a => a.Assays) // dto needed to prevent object cycle loop
            .ToListAsync();
    }

    public async Task<AppUser> GetUserByIdAsync(int id)
    {
        return await _context.Users
            .Include(a => a.Assays)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<AppUser> GetUserByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(a => a.Assays)
            .FirstOrDefaultAsync(x => x.UserName == username);
    }

    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
        return await _context.Users.ProjectTo<MemberDto>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<MemberDto> GetMemberAsync(int id)
    {
        return await _context.Users
            .Where(x => x.Id == id)
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }
}