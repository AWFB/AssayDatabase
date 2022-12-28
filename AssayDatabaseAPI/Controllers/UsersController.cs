using AssayDatabaseAPI.Data;
using AssayDatabaseAPI.DTOs;
using AssayDatabaseAPI.Interfaces;
using AssayDatabaseAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssayDatabaseAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : BaseApiController
{
    private readonly IUserRepo _userRepo;
    private readonly IMapper _mapper;

    public UsersController(IUserRepo userRepo, IMapper mapper)
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }

    [HttpGet]
    // Action result gives access to standard http responses
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers() // list of all users
    {
        var users = await _userRepo.GetMembersAsync();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MemberDto>> GetUser(int id)
    {
        return await _userRepo.GetMemberAsync(id);
    }
}